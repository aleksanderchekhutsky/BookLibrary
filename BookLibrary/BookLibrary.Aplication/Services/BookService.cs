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

        public List<BookDTO> GetAllBooks()
        {
            var booksResponse = _bookRepository.GetAllBooks();
            return _mapper.Map<List<BookDTO>>(booksResponse);
        }

        public BookDTO AddBook(Book bookRequest)
        {

            var bookResponse = _bookRepository.AddBook(bookRequest);
            return _mapper.Map<BookDTO>(bookResponse);
        }

        public BookDTO UpdateBook(Book book)
        {
            var bookResponse = _bookRepository.UpdateBook(book);
            return _mapper.Map<BookDTO>(bookResponse);
        }

        public bool DeleteBook(int? id)
        {
            return _bookRepository.DeleteBook(id);
        }

        public List<Book> SearchBooksByTitle(string title)
        {
            return _bookRepository.GetBookByTitle(title);
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
            return _bookRepository.GetBooksByAuthor(authorId);
        }
        public BookDTO CheckoutBook(int bookId)
        {
            var bookResponse = new Book();
            var book = _bookRepository.GetBookById(bookId);
            if (book != null && !book.IsCheckedOut)
            {
                book.IsCheckedOut = true;
                bookResponse = _bookRepository.UpdateBook(book);
            }
            return _mapper.Map<BookDTO>(bookResponse);
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
