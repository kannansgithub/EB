using EB.Domain.Bases;
using EB.Domain.Contstants;
using EB.Domain.Exceptions;
using EB.Domain.Interfaces;

namespace EB.Domain.Entities;

public class Category: BaseEntityCommon, IAggregateRoot
{
    public virtual ICollection<SubCategory> SubCategories { get; set; } = [];

    //public Category() : base() { } //for EF Core
    //public Category(
    //    string? userId,
    //    string name,
    //    string? description):base(userId,name,description)
    //{
        
    //}
    //public void Update(
    //    string? userId,
    //    string name,
    //    string? description)
    //{
    //    Name = name.Trim();
    //    Description = description?.Trim();
    //    SetAsUpdated(userId);
    //}
    //public void Delete(string? userId)
    //{
    //    foreach (var subCategory in SubCategories)
    //    {
    //        DeleteSubCategory(userId, subCategory.Id);
    //    }
    //    SetAsDeleted(userId);
    //}
    //public SubCategory DeleteSubCategory(string? userId, string subcategoryId)
    //{
    //    var subCategory = SubCategories.FirstOrDefault(c => c.Id == subcategoryId)?? throw new DomainException($"{ExceptionConsts.EntitiyNotFound} with Id {subcategoryId}");
    //    subCategory.Delete(userId);
    //    return subCategory;
    //}
    //public SubCategory CreateSubCategory(
    //    string? userId
    //    )
    //{

    //}
}
