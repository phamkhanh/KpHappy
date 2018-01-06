using System;
using System.Linq;
using KpHappy.Data.Infrastructure;
using KpHappy.Data.Repositories;
using KpHappy.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KpHappy.UnitTest.RepositoryTest
{
    [TestClass]
    public class ErrorRepositoryTest
    {
        IDbFactory dbFactory;
        IErrorRepository objRepository;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new ErrorRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void Error_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void Error_Repository_Create()
        {
            Error error = new Error();
            error.Message = "Test error";
            error.StackTrace = "Test-error";
            error.CreatedDate = DateTime.Now;

            var result = objRepository.Add(error);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.ID);
        }

    }
}
