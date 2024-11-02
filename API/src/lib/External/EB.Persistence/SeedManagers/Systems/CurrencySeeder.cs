using EB.Application.Extensions;
using EB.Application.Services.Repositories;
using EB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.SeedManagers.Systems;

public class CurrencySeeder(
    IBaseCommandRepository<Currency> repository,
    IUnitOfWork unitOfWork)
{
    private readonly IBaseCommandRepository<Currency> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task GenerateDataAsync()
    {
        var currencies = new List<(string Name, string Code, string Symbol)>
            {
                ("Indian Rupee","INR", "₹"),
                ("US Dollar","USD", "$"),
                ("Euro","EUR", "€"),
                ("British Pound","BWP", "£"),
                ("Japanese Yen","JPY", "¥"),
                ("Indonesian Rupiah","IDR", "Rp"),
                ("Srilanga Rupee","LKR", "Rp"),
            };

        foreach (var (name,code, symbol) in currencies)
        {
            var entity = await _repository
                .GetQuery()
                .ApplyIsDeletedFilter()
                .Where(x => x.Name == name)
                .SingleOrDefaultAsync();

            if (entity == null)
            {
                var newCurrency = new Currency(
                    null,
                    code,
                    name,
                    symbol,
                    null);

                await _repository.CreateAsync(newCurrency);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}