using System;
using KpHappy.Data;

namespace KpHappy.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        KpHappyDbContext Init();
    }
}