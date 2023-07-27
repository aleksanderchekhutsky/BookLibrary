using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Interfaces;
using BookLibrary.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infrastructure.Repositories
{
    public class AuthorRepository: IAuthorRepository
    {
        private readonly LibraryDbContext _dbContext;
        public AuthorRepository(LibraryDbContext libraryDbContext)
        {
            _dbContext = libraryDbContext;
        }
        public void AddAuthor(Author author)
        {
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var author = _dbContext.Authors.Find(id);
            if (author != null)
            {
                _dbContext.Authors.Remove(author);
                _dbContext.SaveChanges();
            }
        }

        public List<Author> GetAllAuthors()
        {
            return _dbContext.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _dbContext.Authors.Find(id)!;
        }

        public List<Author> GetAuthorsByBook(int bookId)
        {
            return _dbContext.Authors
                .Where(b => b.Id == bookId)
                .Include(a=>a.BookAuthors)
                .ToList();
        }

        public List<Author> SearchAuthorsByName(string firstName, string lastName)
        {
            return _dbContext.Authors
                .Where(a => a.FirstName.Contains(firstName) && a.LastName.Contains(lastName))
                .ToList();
        }

        public void UpdateAuthor(Author author)
        {
            _dbContext.Authors.Update(author);
            _dbContext.SaveChanges();
        }
    }
}
