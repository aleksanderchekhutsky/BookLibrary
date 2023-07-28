using AutoMapper;
using BookLibrary.Aplication.DTO.Author;
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
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public AuthorDTO GetAuthorById(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            return _mapper.Map<AuthorDTO>(author);
        }

        public List<AuthorDTO> GetAllAuthors()
        {
            var authorsList = _authorRepository.GetAllAuthors();
            return _mapper.Map<List<AuthorDTO>>(authorsList);
        }

        public AuthorDTO AddAuthor(Author author)
        {
            _authorRepository.AddAuthor(author);
            var addedAuthor = _authorRepository.GetAuthorById(author.AuthorId);
            return _mapper.Map<AuthorDTO>(addedAuthor);
        }

        public AuthorDTO UpdateAuthor(Author author)
        {
           var updatedAuthor= _authorRepository.UpdateAuthor(author);
            return _mapper.Map<AuthorDTO>(updatedAuthor);
            
        }

        public bool DeleteAuthor(int id)
        {
            return _authorRepository.DeleteAuthor(id);
        }

        public List<Author> SearchAuthorsByName(string firstName, string lastName)
        {
            return _authorRepository.SearchAuthorsByName(firstName, lastName);
        }
        public bool AuthorExists(string firstName, string lastName)
        {
            return _authorRepository.AuthorExists(firstName, lastName);
        }
    }
}
