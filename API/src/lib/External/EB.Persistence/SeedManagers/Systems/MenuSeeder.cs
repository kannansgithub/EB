﻿using EB.Application.Extensions;
using EB.Application.Services.Repositories;
using EB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace EB.Persistence.SeedManagers.Systems;

public class MenuSeeder(
    IBaseCommandRepository<Menu> repository,
    IUnitOfWork unitOfWork)
{
    private readonly IBaseCommandRepository<Menu> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private static readonly string jsonNavigation = """
    [
      {
        "Name": "Dashboard",
        "Caption": "Dashboard",
        "URI": "/dashboard",
        "Icon": "BiSolidDashboard",
      },
      {
        "Name": "Configuration",
        "Caption": "Configuration",
        "URI": "#",
        "Icon": "BiCog",
        "Sub": [
          {
            "Name": "Menu",
            "Caption": "Menu",
            "URI": "/menus",
            "Icon": "BiMenuAltLeft",
    
          },
        ]
      }
      
    ]
    """;
    public async Task GenerateDataAsync()
    {
        List<Menu>? contributors = JsonSerializer.Deserialize<List<Menu>>(jsonNavigation, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true,
        });
        if (contributors?.Count > 0)
        {
            foreach (var contributor in contributors)
            {
               await InsertMenuAsync(contributor);
            }

        }
    }
    public async Task InsertMenuAsync(Menu menu)
    {
        var entity = await _repository
                  .GetQuery()
                  .ApplyIsDeletedFilter()
                  .Where(x => x.Name == menu.Name)
                  .SingleOrDefaultAsync();
        if (entity == null)
        {
            menu.Roles = ["SuperAdmin"];
            menu.HasReadAccess = true;
            menu.HasWriteAccess = true;
            menu.HasUpdateAccess = true;
            menu.HasDeleteAccess = true;
            // First, add the parent menu
            await _repository.CreateAsync(menu);
            await _unitOfWork.SaveAsync();

            //// If the menu has children, insert them recursively
            //if (menu.Children != null && menu.Children.Count != 0)
            //{
            //    foreach (var child in menu.Children)
            //    {
            //        // Set the ParentId of the child if necessary (assuming you have a ParentId column)
            //        // If you have a self-referencing relationship, make sure to set the ParentId or Parent reference properly.
            //        child.ParentId = menu.Id;
            //        child.Roles = ["SuperAdmin"];
            //        // Recursively insert the child menu
            //        await InsertMenuAsync(child);
            //    }
            //}
        }

    }
}
