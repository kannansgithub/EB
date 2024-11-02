using EB.Application.Services.CQS.Commands;
using Microsoft.EntityFrameworkCore;

namespace EB.Persistence.DataAccessManagers.EFCores.Contexts;

public class CommandContext(DbContextOptions<DataContext> options) : DataContext(options), ICommandContext
{
}
