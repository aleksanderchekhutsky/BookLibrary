using BookLibrary.Aplication.DTO.Author;
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
        public AuthorDTO GetAuthorById(int id);
        public List<AuthorDTO> GetAllAuthors();
        public AuthorDTO AddAuthor(Author author);
        public AuthorDTO UpdateAuthor(Author author);
        bool DeleteAuthor(int id);
        public List<Author> SearchAuthorsByName(string firstName, string lastName);
        public bool AuthorExists(string firstName, string lastName);
    }
}
