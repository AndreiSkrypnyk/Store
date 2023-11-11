using AutoMapper;
using BookStore.Core.Entities;

namespace BookStore.Application.DTOs
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<Book, BookInfoDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
