using EB.Application.Extensions;
using EB.Application.Services.Externals;
using EB.Application.Services.Repositories;
using EB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.SeedManagers.Systems;

public class ConfigSeeder(
    IBaseCommandRepository<Config> config,
    IBaseCommandRepository<Currency> currency,
    IUnitOfWork unitOfWork,
    IEncryptionService encryptionService)
{
    private readonly IBaseCommandRepository<Config> _config = config;
    private readonly IBaseCommandRepository<Currency> _currency = currency;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IEncryptionService _encryptionService = encryptionService;

    public async Task GenerateDataAsync()
    {
        var inr = await _currency
            .GetQuery()
            .ApplyIsDeletedFilter()
            .Where(x => x.Name == "Indian Rupee")
            .SingleOrDefaultAsync();

        var environments = new List<string>
        {
            "Production",
            "Staging",
            "Development"
        };

        var index = 1;
        foreach (var environment in environments)
        {

            if (inr != null)
            {
                var entity = new Config(
                    null,
                    environment,
                    null,
                    inr.Id,
                    "smtp.gmail.com",
                    465,
                    "dummy_username",
                    _encryptionService.Encrypt("dummy_password"),
                    false,
                    index == 1
                    );

                await _config.CreateAsync(entity);
                index++;
            }

        }


        await _unitOfWork.SaveAsync();

    }
}
