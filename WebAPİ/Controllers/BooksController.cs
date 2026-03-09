using Azure;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;



namespace WebAPİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager; 
        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }



        [HttpGet]
        public IActionResult GetAllBooks() //  IActionResult Controller metodlarının HTTP response döndürmesini sağlar
        {
            try
            {
                var books = _manager
                    .BookService
                    .GetAllBooks(false); 
                return Ok(books); // 200 OK status code ile birlikte kitapları döndürür
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{id:int}")] // id parametresini URL'den alır
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {

            try
            {
                var book = _manager // id'ye göre kitabı veritabanından çek
                  .BookService
                    .GetOneBookById(id, false);

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

                
                _manager.BookService.CreateOneBook(book);  // kitabı veritabanına ekle
                

                return StatusCode(201, book); // 201 Created status code ile birlikte oluşturulan kitabı döndürür);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            try
            {
                if (book == null)
                    return BadRequest();

                _manager.BookService.UpdateOneBook(id, book, true); // kitabı veritabanında güncelle
                return NoContent();  //204 No Content

            }
            catch (Exception ex) // herhangi bir hata durumunda exception fırlatır
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                _manager.BookService.DeleteOneBook(id, false); // kitabı veritabanından sil
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
                var entity = _manager
                    .BookService
                    .GetOneBookById(id, true); // id'ye göre kitabı veritabanından çek (trackChanges: true)

                if (entity is null)
                    return NotFound();

                bookPatch.ApplyTo(entity);
                _manager.BookService.UpdateOneBook(id, entity, true); // güncellenmiş kitabı veritabanında kaydet
                 return NoContent(); // 204 No Content status code döndürür

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
