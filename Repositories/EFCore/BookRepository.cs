using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EFCore
{
    public class BookRepository : RepositoryBase<Book>
    {
        public BookRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneBook(Book book) => Create(book);


        public void DeleteOneBook(Book book) => Delete(book);


        public IQueryable<Book> GetAllBooks(bool trackChanges) => 
            FindAll(trackChanges);

        public Book GetOneBookId(int id, bool trackChanges)=> FindByCondition(b => b.Id.Equals(id), trackChanges).SingleOrDefault();


        public void UpdateOneBook(Book book) => Update(book);

    }
}
