namespace Domain.Exceptions;

public class NotFoundException(string entityName, int id) 
    : InvalidOperationException($"Entity of type {entityName} with id {id} was not found.");
