using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Domain.Entities;
using BookLibrary.Aplication.DTO;
using BookLibrary.Aplication.DTO.Book;

namespace BookLibrary.Aplication.Interfaces
{
    public interface IBookService
    {
        public Book GetBookById(int id);
        public List<BookDTO> GetAllBooks();
        public BookDTO AddBook(Book bookModel);
        public BookDTO UpdateBook( Book book);
        public bool DeleteBook(int? id);
        public List<Book> SearchBooksByTitle(string title);
        public List<Book> GetBooksByAuthor(int authorId);
        public BookDTO CheckoutBook(int bookId);
        public void ReturnBook(int bookId);
        public bool BookExists(string title);


    }
}
