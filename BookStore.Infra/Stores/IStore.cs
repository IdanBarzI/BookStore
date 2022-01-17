using BookStore.Domain.Models;
using BookStore.Infra.Repositories.IRepositrories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infra.Worker
{
    public interface IStore : IDisposable
    {
        IRepository<Book> Books { get; }
        IRepository<Journal> Journals { get; }

        int Complete();
        new void Dispose();
    }
}
