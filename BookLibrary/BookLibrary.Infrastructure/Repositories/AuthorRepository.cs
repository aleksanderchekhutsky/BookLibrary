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
        public Author AddAuthor(Author author)
        {
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
            var addedAuthor = _dbContext.Authors.Where(a => a.AuthorId == author.AuthorId).FirstOrDefault();
            return addedAuthor!;
            
        }

        public bool DeleteAuthor(int id)
        {
            var author = _dbContext.Authors.Find(id);
            if (author != null)
            {
                _dbContext.Authors.Remove(author);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Author> GetAllAuthors()
        {
            return _dbContext.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            var author = _dbContext.Authors.Find(id);
           
            return author!;
        }
       
        public List<Author> SearchAuthorsByName(string firstName, string lastName)
        {
            return _dbContext.Authors
                .Where(a => a.FirstName.Contains(firstName) && a.LastName.Contains(lastName))
                .ToList();
        }

        public Author UpdateAuthor(Author author)
        {
            _dbContext.Authors.Update(author);
            _dbContext.SaveChanges();

            Author updatedAuthor= _dbContext.Authors.Where(a => a.AuthorId == author.AuthorId).FirstOrDefault();
            return updatedAuthor!;
            
        }
        public bool AuthorExists(string firstName, string lastName)
        {
            return _dbContext.Authors.Any(a => a.FirstName == firstName && a.LastName == lastName);
        }
    }
}
