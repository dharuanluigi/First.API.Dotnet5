using First.API.Business;
using First.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace First.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookBusiness _bookBusiness;
        private readonly ILogger<BookController> _logger;
        public BookController(IBookBusiness bookBusiness, ILogger<BookController> logger)
        {
            _bookBusiness = bookBusiness;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bookBusiness.GetAllBooks());
        }

        [HttpGet("{id}")]
        public IActionResult GetABookById(int id)
        {
            var result = _bookBusiness.GetABookById(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (book != null)
            {
                var result = _bookBusiness.Add(book);

                if (result != null)
                {
                    return Ok(result);
                }

                return BadRequest("The model of book isn't corrent");
            }

            return BadRequest("Invalid sender model");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookBusiness.Remove(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book updatedBook)
        {
            var result = _bookBusiness.Update(updatedBook);

            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest("Invalid arguments to set in body");
        }
    }
}
