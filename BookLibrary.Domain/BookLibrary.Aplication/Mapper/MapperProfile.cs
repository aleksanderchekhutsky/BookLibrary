using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookLibrary.Aplication.DTO.Book;
using BookLibrary.Domain.Entities;
namespace BookLibrary.Aplication.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<Book, BookCreateDTO>();
            CreateMap<Book, BookDTO>();
        }
    }
}
