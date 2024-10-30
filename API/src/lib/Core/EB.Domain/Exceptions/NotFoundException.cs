namespace EB.Domain.Exceptions;

public sealed class NotFoundException(string entity,string id):Exception($"The {entity} with the ID = {id} was not found");
