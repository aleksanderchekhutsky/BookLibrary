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
        Author AddAuthor(Author author);
        Author UpdateAuthor(Author author);
        bool DeleteAuthor(int id);
        List<Author> SearchAuthorsByName(string firstName, string lastName);
        bool AuthorExists(string firstName, string lastName);
    }
}
