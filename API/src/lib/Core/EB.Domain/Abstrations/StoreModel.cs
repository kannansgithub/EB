namespace EB.Domain.Abstrations;

public record StoreResponse(
    string Id,
    string clientId,
    string Code,
    string Name,
    string Description,
    string? AddressLine1,
    string? AddressLine2,
    string? AddressLine3,
    string? City,
    string? Region,
    string? PostalCode,
    string? Country,
    string? PhoneNumber,
    string? Fax
    );
public record StoreModel(
    string clientId,
    string Code,
    string Name, 
    string Description,
    string? AddressLine1,
    string? AddressLine2,
    string? AddressLine3,
    string? City,
    string? Region,
    string? PostalCode,
    string? Country,
    string? PhoneNumber,
    string? Fax
);
