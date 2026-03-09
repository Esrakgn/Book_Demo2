using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        Contracts.IBookService IServiceManager.BookService => throw new NotImplementedException();
    }
}
