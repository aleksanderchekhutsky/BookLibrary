using BookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Aplication.Interfaces
{
    public interface IAuthorService
    {
        public Author GetAuthorById(int id);
        public List<Author> GetAllAuthors();
        public void AddAuthor(Author author);
        public void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
        public List<Author> SearchAuthorsByName(string firstName, string lastName);
        public List<Author> GetAuthorsByBook(int bookId);
    }
}
