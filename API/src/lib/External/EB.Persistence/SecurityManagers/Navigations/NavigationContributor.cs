﻿
namespace EB.Persistence.SecurityManagers.Navigations;

public class NavigationChild
{
    public string Name { get; set; } = null!;
    public string Caption { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string? Permission { get; set; }
}

public class NavigationContributor
{
    public string ParentName { get; set; } = null!;
    public string ParentCaption { get; set; } = null!;
    public string ParentUrl { get; set; } = null!;
    public List<NavigationChild> Children { get; set; } = [];

}

