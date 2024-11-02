﻿namespace EB.Application.Services.Externals;

public interface IImageService
{
    Task<string> UploadAsync(
        string? userId,
        string originalFileName,
        string imgExtension,
        byte[] fileData,
        long size,
        CancellationToken cancellationToken = default);
    Task<byte[]> GetFileAsync(string fileName, CancellationToken cancellationToken = default);
}
