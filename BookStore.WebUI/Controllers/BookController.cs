using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookManager _bookManager;
        private readonly IMapper _mapper;
        

        public BookController(ILogger<BookController> logger, IBookManager bookManager, IMapper mapper)
        {
            _logger = logger;
            _bookManager = bookManager;
            _mapper = mapper;
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
           var bookDTOs = _mapper.Map<BookInfoDTO>(book);

          return View(bookDTOs);
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