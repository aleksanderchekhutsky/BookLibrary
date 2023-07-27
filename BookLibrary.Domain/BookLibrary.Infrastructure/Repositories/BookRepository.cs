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
            //foreach (var author in book.Authors)
            //{
            //    _dbContext.Authors.Attach(author);
            //}

            _dbContext.Books.Add(book);
            _dbContext.SaveChangesAsync();
            //return _dbContext.Books
            // .Include(b => b.BookAuthors)
            //     .ThenInclude(ba => ba.Authors)
            // .FirstOrDefaultAsync(b => b.Id == book.Id);

            // Return the complete book object, including the authors
            //var completeBook =  _dbContext.Books
            //    .Include(b => b.Authors)
            //    .FirstOrDefault(b => b.Id == book.Id);

            //return completeBook!;
            //var savedBook =_dbContext.Books.Add(book);
            //_dbContext.SaveChanges();
            //return savedBook.Entity;
            // return book;
            var createdBook = _dbContext.Books.Where(b => b.Id == 1).Include(a => a.Authors).FirstOrDefault();
           
            return createdBook!;
           // return (_dbContext.Books.Where(b=>b.Id== book.Id).Include(a => a.Author).FirstOrDefault())!;
            
        }

        public bool BookExists(string title)
        {
            return _dbContext.Books.Any(b => b.Title == title);
        }

        public bool DeleteBook(int? id)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.Id == id);
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
            return _dbContext.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            //var book = _dbContext.Books.Include(b => b.BookAuthors).ThenInclude(e => e.BookAuthors).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            var book = _dbContext.Books
                .Where(x => x.Id == id)
                .Include(a => a.Authors).FirstOrDefault();
            return book!;
            //return  _dbContext.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == id);
            //return _dbContext.Books.Find(id)!;
            //return _dbContext.Books
            //   .Include(book => book.Authors) // Include authors in the query
            //   .FirstOrDefault(book => book.Id == id)!;
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
            return _dbContext.Books
                .Where(b => b.Authors.Any(a => a.Id == authorId))
                .ToList();
        }

        public List<Book> SearchBooksByTitle(string title)
        {
            return _dbContext.Books
                .Where(b => b.Title.Contains(title))
                .ToList();
        }

        public void UpdateBook(Book book)
        {
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }
    }
}
