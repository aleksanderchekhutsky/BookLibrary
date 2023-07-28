using BookLibrary.Aplication.DTO.Author;
using BookLibrary.Aplication.Interfaces;
using BookLibrary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Returns  Author by Id ", Description = "This enpoint return  Author")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AuthorDTO>))]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(List<AuthorDTO>))]
        public ActionResult<List<AuthorDTO>> GetAllAuthor()
        {
            var allAuthors = _authorService.GetAllAuthors();
            return Ok(allAuthors);
           
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Returns all Authors", Description = "This enpoint return Authors")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AuthorDTO>))]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(List<AuthorDTO>))]
        public ActionResult<AuthorDTO> GetAuthorById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var author = _authorService.GetAuthorById(id);
                if(author == null)
                {
                    return BadRequest("author not found");
                }
                return Ok(author);


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while searching the author.");
            }
        }

        // POST api/<AuthorController>
        [HttpPost]
        [SwaggerOperation(Summary = "Create Authors", Description = "This enpoint create and return  Author")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDTO))]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(AuthorDTO))]
        public ActionResult<AuthorDTO> AddAuthor([FromBody] Author authorRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var authorResponse = _authorService.AddAuthor(authorRequest);
                if(authorResponse != null)
                {
                    return Ok(authorResponse);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the author.");
            }
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update Author ", Description = "This enpoint update and return  Author")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDTO))]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(AuthorDTO))]
        public ActionResult<AuthorDTO> UpdateAuthor(int authorId,[FromBody] Author authoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_authorService.AuthorExists(authoRequest.FirstName, authoRequest.LastName))
            {
                return BadRequest("Author not found ");

            }
            try
            {
                authoRequest.AuthorId = authorId;
                var authorResponse = _authorService.UpdateAuthor(authoRequest);
                return Ok(authorResponse);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the author.");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete Author ", Description = "This enpoint update and return  Author")]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                if (_authorService.DeleteAuthor(id))
                {
                    return Ok(new { Id = id });
                }
                return BadRequest("Author not found");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the author.");
            }
            
        }
    }
}
