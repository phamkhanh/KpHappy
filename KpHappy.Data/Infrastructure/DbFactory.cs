using KpHappy.Data;

namespace KpHappy.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private KpHappyDbContext dbContext;

        public KpHappyDbContext Init()
        {
            return dbContext ?? (dbContext = new KpHappyDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}