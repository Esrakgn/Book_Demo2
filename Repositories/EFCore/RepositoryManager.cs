using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        //private readonly Lazy<IBookService> _bookRepository; 
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            //_bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
        
        }

        //public IBookRepository Book => _bookRepository.Value;

        BookRepository IRepositoryManager.Book => throw new NotImplementedException();

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

//lazy loading: nesne sadece ihtiyaç duyulduğunda oluşturulur, performansı artırır
//eager loading: nesne hemen oluşturulur