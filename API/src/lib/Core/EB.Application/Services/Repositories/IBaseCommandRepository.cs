﻿using EB.Domain.Bases;
using EB.Domain.Interfaces;

namespace EB.Application.Services.Repositories;


public interface IBaseCommandRepository<T> where T : BaseEntity, IAggregateRoot
{
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);

    void Create(T entity);

    void Update(T entity);

    void Delete(T entity);

    void Purge(T entity);

    Task<T?> GetAsync(string id, CancellationToken cancellationToken = default);

    T? Get(string id);

    IQueryable<T> GetQuery();
}

