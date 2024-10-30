using EB.Domain.Entities;
using EB.Domain.Shared;

namespace EB.Domain.Repositories;

public interface IVendorRepository: IGenericRepository<Vendor>
{
    Task<Vendor?> GetByContact(string contact);
}
