using AutoMapper;
using BookLibrary.Aplication.DTO.Book;
using BookLibrary.Aplication.Interfaces;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Aplication.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public List<Book> GetAllBooks()
        {
            return new List<Book> {
                new Book { Id = 0, Description = "desc1", ImageUrl="testurl1", IsCheckedOut = true, PublicationDate = DateTime.Now, Title= "title" },
                new Book { Id = 2, Description = "desc1", ImageUrl="testurl2", IsCheckedOut = true, PublicationDate = DateTime.Now, Title= "title" },
                new Book { Id = 3, Description = "desc1", ImageUrl="testurl3", IsCheckedOut = true, PublicationDate = DateTime.Now, Title= "title" },
            };
            //return _bookRepository.GetAllBooks();
        }

        public BookDTO AddBook(Book bookRequest)
        {
            //var mapedBook = _mapper.Map<Book>(bookRequest);

            var bookResponse = _bookRepository.AddBook(bookRequest);
            return _mapper.Map<BookDTO>(bookResponse);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
        }

        public bool DeleteBook(int? id)
        {
            return _bookRepository.DeleteBook(id);
        }

        public List<Book> SearchBooksByTitle(string title)
        {
            return _bookRepository.SearchBooksByTitle(title);
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
            return _bookRepository.GetBooksByAuthor(authorId);
        }

        public void CheckoutBook(int bookId, int borrowerId)
        {
            var book = _bookRepository.GetBookById(bookId);
            if (book != null && !book.IsCheckedOut)
            {
                book.IsCheckedOut = true;
                _bookRepository.UpdateBook(book);
            }
        }
        public void ReturnBook(int bookId)
        {
            var book = _bookRepository.GetBookById(bookId);
            if (book != null && book.IsCheckedOut)
            {
                book.IsCheckedOut = false;
                _bookRepository.UpdateBook(book);
            }
        }

        public bool BookExists(string ttitle)
        {
            return _bookRepository.BookExists(ttitle);
        }
    }
}
