using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KpHappy.Data.Infrastructure;
using KpHappy.Data.Repositories;
using KpHappy.Model.Models;

namespace KpHappy.Service
{
    public interface IErrorService
    {
        Error Create(Error error);
        IEnumerable<Error> GetAll();
        Error Add(Error error);
        void Save();
    }
    public class ErrorService : IErrorService
    {
        IErrorRepository _errorRepository;
        IUnitOfWork _unitOfWork;
        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public Error Add(Error error)
        {
            return _errorRepository.Add(error);
        }

        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public IEnumerable<Error> GetAll()
        {
            return _errorRepository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
