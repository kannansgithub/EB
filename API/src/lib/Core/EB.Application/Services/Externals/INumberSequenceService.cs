﻿namespace EB.Application.Services.Externals;

public interface INumberSequenceService
{
    string GenerateNumberSequence(
        string? userId,
        string entityName,
        string? prefix,
        string? suffix,
        bool useDate = true,
        int padding = 4);
}
