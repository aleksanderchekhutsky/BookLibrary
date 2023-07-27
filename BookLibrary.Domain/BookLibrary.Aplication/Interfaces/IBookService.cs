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
        public List<Book> GetAllBooks();
        public BookDTO AddBook(Book bookModel);
        public void UpdateBook(Book book);
        public bool DeleteBook(int? id);
        public List<Book> SearchBooksByTitle(string title);
        public List<Book> GetBooksByAuthor(int authorId);
        public void CheckoutBook(int bookId, int borrowerId);
        public void ReturnBook(int bookId);
        public bool BookExists(string ttitle);


    }
}
