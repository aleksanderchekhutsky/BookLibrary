using BookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using BookLibrary.Aplication.DTO.Book;

namespace BookLibrary.Domain.Interfaces
{
    public interface IBookRepository
    {
        Book GetBookById(int id);
        List<Book> GetAllBooks();
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        bool DeleteBook(int? id);
        List<Book> GetBookByTitle(string title);
        List<Book> GetBooksByAuthor(int authorId);
        bool BookExists (string title);
        
    }
}
