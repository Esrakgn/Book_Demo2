using Repositories.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        BookRepository Book { get; }
        void Save();
    }
}
