using BookLibrary.Aplication.DTO.Book;
using BookLibrary.Aplication.Interfaces;
using BookLibrary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IBookService bookService, IWebHostEnvironment webHostEnvironment)
        {
            _bookService = bookService;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: api/<BookController>
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }
        //[HttpPost]
        //public ActionResult<Book> AddBook([FromBody] Book bookModel)
        //{
        //    if (bookModel == null)
        //    {
        //        return BadRequest("Book object is null");
        //    }
        //    if(!ModelState.IsValid)
        //    {
        //        return BadRequest("Invalid Book");
        //    }
        //     var createdBook = _bookService.AddBook(bookModel);

        //    return Ok(createdBook);
        //}
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[SwaggerOperation("UploadImage")]
        public ActionResult<BookDTO> AddBook( Book bookModel, [FromForm] IFormFile Photo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(bookModel.Title))
            {
                return BadRequest("Book Title is required!");
            }

                //}
                //if (bookModel.Authors == null || !bookModel.Authors.Any())
                //{
                //    return BadRequest("At least one author is required for the book.");
                //}
                if (_bookService.BookExists(bookModel.Title))
                {
                    return Conflict("A book with the same title already exists.");
                }
                try
                {
                    // Save the uploaded image to the server
                    if (bookModel.Photo != null)
                    {
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + bookModel.Photo.FileName;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            bookModel.Photo.CopyTo(stream);
                        }

                        // Set the image URL in the book entity
                        bookModel.ImageUrl = $"/images/{uniqueFileName}";
                    }
                   

                var createdBook = _bookService.AddBook(bookModel);

                    //var responseModel = new Book
                    //{
                    //    Id = addedBook.Id,
                    //    Title = addedBook.Title,
                    //    Description = addedBook.Description,
                    //    ImageUrl = addedBook.ImageUrl,
                    //    Rating = addedBook.Rating,
                    //    PublicationDate = addedBook.PublicationDate,
                    //    IsCheckedOut = addedBook.IsCheckedOut
                    //};

                    //return Ok(new { Id = addedBook.Id });
                    return Ok(createdBook);

                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the book.");
                }
            }
            //[SwaggerOperation("UploadImage")]
            //public ActionResult AddBook([FromForm] Book bookModel)
            //{
            //    if (bookModel == null)
            //    {
            //        return BadRequest("Book object is null");
            //    }

            //    if (!ModelState.IsValid)
            //    {
            //        return BadRequest(ModelState);
            //    }          

            //    try
            //    {
            //        // Save the uploaded image to the server
            //        if (bookModel.Photo != null)
            //        {
            //            string uniqueFileName = Guid.NewGuid().ToString() + "_" + bookModel.Photo.FileName;
            //            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);
            //            using (var stream = new FileStream(filePath, FileMode.Create))
            //            {
            //                bookModel.Photo.CopyTo(stream);
            //            }

            //            // Set the image URL in the book entity
            //            bookModel.ImageUrl = $"/images/{uniqueFileName}";
            //        }

            //        var addedBook = _bookService.AddBook(bookModel);

            //        var responseModel = new Book
            //        {
            //            Id = addedBook.Id,
            //            Title = addedBook.Title,
            //            Description = addedBook.Description,
            //            ImageUrl = addedBook.ImageUrl,
            //            Rating = addedBook.Rating,
            //            PublicationDate = addedBook.PublicationDate,
            //            IsCheckedOut = addedBook.IsCheckedOut
            //        };

            //        return Ok(new { Id = addedBook.Id });

            //    }
            //    catch (Exception)
            //    {
            //        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the book.");
            //    }
            //}
            [HttpDelete("id")]
            public ActionResult DeleteBook(int? bookId)
            {
                if (bookId == null)
                {
                    return BadRequest();
                }
                try
                {
                    var result = _bookService.DeleteBook(bookId);
                    if (result == false)
                    {
                        return NotFound();
                    }
                    return Ok(new { Id = bookId });

                }
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal error");
                }
            }
            [HttpGet("{id}")]

            public ActionResult<Book> GetBookById(int id)
            {
                var result = _bookService.GetBookById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }



        }
    }
