using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Repositories.IRepositories;
using BookStore.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace BookStore.WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookManager _bookManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        

        public BookController(ILogger<BookController> logger, IBookManager bookManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _bookManager = bookManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        public IActionResult Index()
        {
            var books = _bookManager.GetBooks(); 
            var bookDTOs = _mapper.Map<IList<BookDTO>>(books); 

            return Json(bookDTOs);
        }

        public IActionResult Books()
        {
            var books = _bookManager.GetBooks();
            var bookDTOs = _mapper.Map<IList<BookDTO>>(books);

            return View(bookDTOs);
        }

        public IActionResult BookInfo(int Id)
        {
            var book = _bookManager.GetBook(Id);
            ShoppingCart cart = new()
            {
                Book = book,
                Count = 1,
                BookId = Id
            };

           //var bookDTOs = _mapper.Map<BookInfoDTO>(book);

          return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult BookInfo(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId= userId;
            shoppingCart.Id = 0;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId &&
            u.BookId == shoppingCart.BookId);

            if (cartFromDb != null)
            {
                //shopping cart exists
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
                _unitOfWork.Save();
            }
            else
            {
                //add cart record
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                _unitOfWork.Save();
            }
            TempData["success"] = "Cart updated successfully";

            return RedirectToAction(nameof(Books));
        }

        public IActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return new EmptyResult();
            }
            else
            {
                var books = _bookManager.GetBookByName(query);
                var bookDTOs = _mapper.Map<IList<BookDTO>>(books);

                ViewBag.Query = query;

                return View("Books", bookDTOs);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}