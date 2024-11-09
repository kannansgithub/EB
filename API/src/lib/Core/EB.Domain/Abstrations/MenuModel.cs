namespace EB.Domain.Abstrations;

public record MenuModel(
    string Name, 
    string Caption, 
    string URI, 
    string? Icon, 
    bool HasReadAccess, 
    bool HasWriteAccess,
    bool HasUpdateAccess,
    bool HasDeleteAccess,
    string[] Roles,
    List<MenuModel> Children);
public record MenuRequest(
    string Name,
    string Caption,
    string Url,
    string Icon,
    bool IsAuthorized,
    bool HasReadAccess,
    bool HasWriteAccess,
    bool HasUpdateAccess,
    bool HasDeleteAccess,
    int Index,
    int ParentIndex,
    List<MenuRequest> Children
);

