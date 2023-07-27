using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Entities
{
    public class Author
    {
       // [JsonIgnore]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? YearOfBirth { get; set; }
        //[JsonIgnore]
        // public List<Book> Books { get; set; }
        [JsonIgnore]
        public List<Book> BookAuthors { get; set; }
    }
}
