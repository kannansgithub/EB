namespace EB.Domain.Abstrations;

public record MenuModel(
    string Name, 
    string Caption, 
    string URI, 
    string? Label, 
    string? Icon,
    string? ParentId,
    bool HasReadAccess, 
    bool HasWriteAccess,
    bool HasUpdateAccess,
    bool HasDeleteAccess,
    string[] Roles,
    List<MenuModel> Sub);
public record MenuRequest(
    string Name,
    string Caption,
    string Url,
    string Label,
    string Icon,
    bool IsAuthorized,
    bool HasReadAccess,
    bool HasWriteAccess,
    bool HasUpdateAccess,
    bool HasDeleteAccess,
    int Index,
    int ParentIndex,
    List<MenuRequest> Sub
);

