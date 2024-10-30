using EB.Domain.Entities;
using EB.Domain.Shared;

namespace EB.Domain.Repositories;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<Customer?> GetByContact(string contact);
}
