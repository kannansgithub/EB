﻿using EB.Domain.Entities;
using EB.Domain.Repositories;
using EB.Persistence.Abstrations;
using EB.Persistence.DataAccessManagers.EFCores.Contexts;

namespace EB.Persistence.Repositories;

public class PurchaseReturnRepository(DataContext dbContext) : GenericRepository<PurchaseReturn>(dbContext), IPurchaseReturnRepository
{
}
