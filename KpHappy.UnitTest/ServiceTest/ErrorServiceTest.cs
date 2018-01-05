using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KpHappy.Data.Infrastructure;
using KpHappy.Data.Repositories;
using KpHappy.Model.Models;
using KpHappy.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KpHappy.UnitTest.ServiceTest
{
    [TestClass]
    public class ErrorServiceTest
    {
        private Mock<IErrorRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IErrorService _errorService;
        private List<Error> _listError;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IErrorRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _errorService = new ErrorService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listError = new List<Error>()
            {
                new Error() {ID =1 ,Message="DM1",CreatedDate = DateTime.Now },
                new Error() {ID =2 ,Message="DM2",CreatedDate = DateTime.Now },
                new Error() {ID =3 ,Message="DM3",CreatedDate = DateTime.Now },
            };
        }

        [TestMethod]
        public void Error_Service_GetAll()
        {
            //setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listError);

            //call action
            var result = _errorService.GetAll() as List<Error>;

            //compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void Error_Service_Create()
        {
            Error error = new Error();
            int id = 1;
            error.Message = "Test";
            error.StackTrace = "test";
            error.CreatedDate = DateTime.Now;

            _mockRepository.Setup(m => m.Add(error)).Returns((Error p) =>
            {
                p.ID = 1;
                return p;
            });

            var result = _errorService.Add(error);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);


        }
    }
}
