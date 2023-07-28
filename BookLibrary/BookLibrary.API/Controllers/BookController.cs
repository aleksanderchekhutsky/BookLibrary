using BookLibrary.Aplication.DTO.Book;
using BookLibrary.Aplication.Interfaces;
using BookLibrary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

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

        [HttpGet]
        [SwaggerOperation(Summary = "Returns all books", Description = "This enpoint return list of books")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Book>))]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(List<Book>))]
        public ActionResult<List<GetBookDTO>> GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new book", Description = "This endpoint allows you to create a new book with the provided details.")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDTO))]
       
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public ActionResult<BookDTO> AddBook([FromForm] Book bookModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(bookModel.Title))
            {
                return BadRequest("Book Title is required!");
            }


            if (_bookService.BookExists(bookModel.Title))
            {
                return Conflict("A book with the same title already exists.");
            }
            try
            {
                if (bookModel.Photo != null)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + bookModel.Photo.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        bookModel.Photo.CopyTo(stream);
                    }

                    bookModel.ImageUrl = $"/images/{uniqueFileName}";
                }

                var createdBook = _bookService.AddBook(bookModel);

                return Ok(createdBook);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the book.");
            }
        }

        [HttpDelete("id")]
        [SwaggerOperation(Summary = "Delete book")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteBook(int? bookId)
        {
            if (bookId == null)
            {
                return BadRequest("Id is empty");
            }
            try
            {
                var result = _bookService.DeleteBook(bookId);
                if (result == false)
                {
                    return NotFound("Book not fount");
                }
                return Ok(new { Id = bookId });

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal error");
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Return book by Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<BookDTO> GetBookById(int id)
        {
            var result = _bookService.GetBookById(id);
            if (result == null)
            {
                return NotFound("Book not found");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update book")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookDTO> UpdateBook(int bookId,[FromForm] Book bookModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(bookModel.Title))
            {
                return BadRequest("Book Title is required!");
            }

            if (_bookService.BookExists(bookModel.Title))
            {
                return Conflict("A book with the same title already exists.");
            }

            try
            {
                if (bookModel.Photo != null)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + bookModel.Photo.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        bookModel.Photo.CopyTo(stream);
                    }

                    bookModel.ImageUrl = $"/images/{uniqueFileName}";
                }

                bookModel.BookId = bookId;
                var updatedBook = _bookService.UpdateBook(bookModel);
                return Ok(updatedBook);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal error");
            }   
        }
        [HttpPost("{id}")]
        [SwaggerOperation(Summary = "Checkout book")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BookDTO> CheckOutBook(int bookId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookResponse = _bookService.CheckoutBook(bookId);
            if (bookResponse == null)
            {
                return BadRequest("Book is not exist");
            }
            return Ok(bookResponse);
        }
    }
}
