using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebAPİ.Models;
using WebAPİ.Repositories;

namespace WebAPİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public BooksController(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllBooks() //  IActionResult Controller metodlarının HTTP response döndürmesini sağlar
        {
            try
            {
                var books = _context.Books.ToList();
                return Ok(books); // 200 OK status code ile birlikte kitapları döndürür
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{id}")] // id parametresini URL'den alır
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {

            try
            {
                var book = _context
                 .Books
                 .Where(b => b.Id.Equals(id))
                 .FirstOrDefault(); //404

                if (book == null)
                    return NotFound();
                return Ok(book);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            try
            {
                if (book == null)
                    return BadRequest(); // 400 Bad Request status code döndürür

                _context.Books.Add(book);
                _context.SaveChanges();
                return StatusCode(201, book); // 201 Created status code ile birlikte oluşturulan kitabı döndürür);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            try
            {
                var entity = _context  // güncellenilcek kitap bilgisi
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();

                if (entity is null) // gerçekten var mı
                    return NotFound();

                if (id != book.Id) //check ıd 400
                    return BadRequest();

                entity.Title = book.Title;  //yeni kitap bilgisi ile güncelleme
                entity.Price = book.Price;

                _context.SaveChanges(); //güncellenmiş bilgiyi kaydet

                return Ok(book);

            }
            catch (Exception ex) // herhangi bir hata durumunda exception fırlatır
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();
                if (entity is null)
                    return NotFound();
                _context.Books.Remove(entity);
                _context.SaveChanges();
                return NoContent(); // 204 No Content status code döndürür
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            try
            {
                var entity = _context
                    .Books
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();
                if (entity is null)
                    return NotFound();

                bookPatch.ApplyTo(entity);
                _context.SaveChanges();

                
               
                return Ok(entity); // güncellenmiş kitabı döndür
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
