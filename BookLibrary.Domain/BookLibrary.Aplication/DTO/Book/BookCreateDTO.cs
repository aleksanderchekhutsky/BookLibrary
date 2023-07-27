using BookLibrary.Aplication.DTO.Author;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Aplication.DTO.Book
{
    public class BookCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Rating { get; set; }
        public DateTime? PublicationDate { get; set; }
        public bool IsCheckedOut { get; set; }
        public List<AuthorDTO> Authors { get; set; }
        public IFormFile Photo { get; set; }
        public string ImageUrl { get; set; }
    }
}
