using EB.Domain.Bases;
using EB.Domain.Interfaces;

namespace EB.Domain.Entities;

public class Stock : BaseEntityCommon, IAggregateRoot
{
    public int CurrentStock { get; set; } = 0;
    public int LastSale { get; set; } = 0;

}
