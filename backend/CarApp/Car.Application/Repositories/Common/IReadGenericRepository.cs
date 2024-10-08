﻿using Car.Domain.Entities.Abstracts;

namespace Car.Application.Repositories.Common
{
    public interface IReadGenericRepository<T>:IGenericRepository<T>where T : class,IBaseEntity,new()
    {
        Task<T?> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
