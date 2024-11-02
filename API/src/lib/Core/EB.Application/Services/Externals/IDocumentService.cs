﻿namespace EB.Application.Services.Externals;

public interface IDocumentService
{
    Task<string> UploadAsync(
        string? userId,
        string originalFileName,
        string docExtension,
        byte[] fileData,
        long size,
        CancellationToken cancellationToken = default);

    Task<byte[]> GetFileAsync(string fileName, CancellationToken cancellationToken = default);
}
