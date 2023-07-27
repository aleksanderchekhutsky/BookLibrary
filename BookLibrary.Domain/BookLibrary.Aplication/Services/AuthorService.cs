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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetAuthorById(id);
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }

        public void AddAuthor(Author author)
        {
            _authorRepository.AddAuthor(author);
        }

        public void UpdateAuthor(Author author)
        {
            _authorRepository.UpdateAuthor(author);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.DeleteAuthor(id);
        }

        public List<Author> SearchAuthorsByName(string firstName, string lastName)
        {
            return _authorRepository.SearchAuthorsByName(firstName, lastName);
        }

        public List<Author> GetAuthorsByBook(int bookId)
        {
            return _authorRepository.GetAuthorsByBook(bookId);
        }
    }
}
