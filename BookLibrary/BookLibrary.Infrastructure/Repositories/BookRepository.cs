using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Aplication.DTO.Book;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Interfaces;
using BookLibrary.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;
        public BookRepository(LibraryDbContext libraryDbContext)
        {
            _dbContext = libraryDbContext;

        }
        public Book AddBook(Book book)
        {
            
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            
            var createdBook = _dbContext.Books.Where(b => b.BookId == book.BookId).Include(a => a.Authors).FirstOrDefault();
           
            return createdBook!;
        }

        public bool BookExists(string title)
        {
            return _dbContext.Books.Any(b => b.Title == title);
        }

        public bool DeleteBook(int? id)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.BookId == id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Book> GetAllBooks()
        {
            return _dbContext.Books.Include(b=> b.Authors).ToList();
          
        }

        public Book GetBookById(int id)
        {
            var book = _dbContext.Books
                .Where(x => x.BookId == id)
                .Include(a => a.Authors).FirstOrDefault();
            return book!;
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
            return _dbContext.Books
                .Where(b => b.Authors.Any(a => a.AuthorId == authorId))
                .ToList();
        }

        public List<Book> GetBookByTitle(string title)
        {
            return _dbContext.Books
                .Where(b => b.Title.Contains(title))
                .ToList();
        }

        public Book UpdateBook(Book book)
        {
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
            var updatedBook = _dbContext.Books.Where(b => b.BookId == book.BookId).Include(a => a.Authors).FirstOrDefault();

            return updatedBook!;
        }
       
    }
}
