using Shopinka.Core.Repositories;
using System;

namespace Shopinka.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        int Commit();
    }
}
