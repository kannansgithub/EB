namespace EB.Domain.Abstrations;

public record ClientModel(string Id, string Name, string LogoPath, string PrimaryColor, string SecondaryColor, string TertiaryColor);
public record ClientRequest(string Name, string LogoPath, string PrimaryColor, string SecondaryColor, string TertiaryColor);
