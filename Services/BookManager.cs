using Entities.Models;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using IBookService = Services.Contracts.IBookService;

namespace Services
{
    public class BookManager : IRepositoryManager
    {
        private readonly IRepositoryManager _manager;

        public BookRepository Book => throw new NotImplementedException();

        public BookManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _manager.Book.GetAllBooks(trackChanges);
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            var book = _manager.Book.GetOneBookId(id, trackChanges);

            if (book == null)
                throw new Exception($"Book with id:{id} could not found.");

            return book;
        }

        public Book CreateOneBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _manager.Book.CreateOneBook(book);
            _manager.Save();
            return book;
        }

        public void UpdateOneBook(int id, Book book, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookId(id, trackChanges);

            if (entity == null)
                throw new Exception($"Book with id:{id} could not found.");

            if (book == null)
                throw new ArgumentNullException(nameof(book));

            entity.Title = book.Title;
            entity.Price = book.Price;

            _manager.Book.UpdateOneBook(entity);
            _manager.Save();
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookId(id, trackChanges);

            if (entity == null)
                throw new Exception($"Book with id:{id} could not found.");

            _manager.Book.DeleteOneBook(entity);
            _manager.Save();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
