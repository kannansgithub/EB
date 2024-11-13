namespace EB.Persistence.SecurityManagers.Navigations;

public class NavigationItem
{
    public string Name { get; set; }
    public string Caption { get; set; }
    public string Url { get; set; }
    public string? Icon { get; set; }
    public string? Label { get; set; }
    public bool IsAuthorized { get; set; }
    public bool HasReadAccess { get; set; }
    public bool HasWriteAccess { get; set; }
    public bool HasUpdateAccess { get; set; }
    public bool HasDeleteAccess { get; set; }
    public List<NavigationItem> Children { get; set; } = [];
    public int Index { get; set; }
    public int ParentIndex { get; set; }

    public NavigationItem(
        string name, 
        string caption, 
        string url, 
        string? label , 
        string? icon , 
        bool isAuthorized = false, 
        int index = 1, 
        int parentIndex = 0, 
        bool hasReadAccess = false,
        bool hasWriteAccess = false,
        bool hasUpdateAccess = false,
        bool hasDeleteAccess = false
        )
    {
        Name = name;
        Caption = caption;
        Url = url;
        IsAuthorized = isAuthorized;
        Index = index;
        ParentIndex = parentIndex;
        Label = label;
        Icon = icon;
        HasDeleteAccess = hasDeleteAccess;
        HasUpdateAccess = hasUpdateAccess;
        HasWriteAccess = hasWriteAccess;
        HasReadAccess = hasReadAccess;

    }

    public void AddChild(NavigationItem child)
    {
        Children.Add(child);
    }
}


