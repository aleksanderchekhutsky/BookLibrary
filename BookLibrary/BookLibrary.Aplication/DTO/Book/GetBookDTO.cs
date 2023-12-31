﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Aplication.DTO.Book
{
    public class GetBookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double? Rating { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool IsCheckedOut { get; set; }
    }
}
