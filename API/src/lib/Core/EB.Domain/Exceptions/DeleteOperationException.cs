namespace EB.Domain.Exceptions;

public sealed class DeleteOperationException(string entity, string id) : Exception($"The {entity} asociated with ID = {id} unable to delete");
