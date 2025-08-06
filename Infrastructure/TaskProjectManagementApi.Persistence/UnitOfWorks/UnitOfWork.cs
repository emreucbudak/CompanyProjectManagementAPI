using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProjectManagementApi.Application.Interfaces;
using TaskProjectManagementApi.Application.Interfaces.UnitOfWork;
using TaskProjectManagementApi.Persistence.AppDbContext;
using TaskProjectManagementApi.Persistence.Repositories;

namespace TaskProjectManagementApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _unitOfWork;

        public UnitOfWork(ApplicationDbContext unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async ValueTask DisposeAsync() => await _unitOfWork.DisposeAsync();
        public int Save() => _unitOfWork.SaveChanges();

        public async Task<int> SaveAsync() => await _unitOfWork.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_unitOfWork);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_unitOfWork);
    }
}
