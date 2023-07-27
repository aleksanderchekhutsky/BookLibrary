using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Entities
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public Book Book {get; set; }

        public int AuthorId { get; set; }
        public Author Authors { get; set; }
    }
}
