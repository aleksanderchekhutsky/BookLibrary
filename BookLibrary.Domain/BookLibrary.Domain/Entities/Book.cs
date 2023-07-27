using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Entities
{
    public class Book
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [SwaggerSchema(ReadOnly = true)]

        public string ImageUrl { get; set; }
        public double? Rating { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public DateTime? PublicationDate { get; set; } = DateTime.Now;
        public bool IsCheckedOut { get; set; }
        public List<Author> Authors { get; set; } // List of authors for the book
       // public ICollection<Author> Author { get; set; }
    }
}
