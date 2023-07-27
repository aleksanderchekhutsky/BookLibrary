using BookLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Author GetAuthorById(int id);
        List<Author> GetAllAuthors();
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
        List<Author> GetAuthorsByBook(int bookId);
        List<Author> SearchAuthorsByName(string firstName, string lastName);
    }
}
