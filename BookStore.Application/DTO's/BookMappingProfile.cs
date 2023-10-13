using AutoMapper;
using BookStore.Core.Entities;

namespace BookStore.Application.DTO_s
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookDTO>();
        }
    }
}
