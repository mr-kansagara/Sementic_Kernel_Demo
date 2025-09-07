using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace semantickernelPractice;

public class DirectoryPlugin
{
    [KernelFunction, Description("Create a new directory at the given path")]
    public Task<string> CreateDirectoryAsync(
        [Description("Path where the directory should be created")] string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            return Task.FromResult($"✅ Directory created: {path}");
        }
        return Task.FromResult($"⚠️ Directory already exists: {path}");
    }

    [KernelFunction, Description("Delete a directory and its contents")]
    public Task<string> DeleteDirectoryAsync(
        [Description("Path of the directory to delete")] string path)
    {
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
            return Task.FromResult($"🗑️ Directory deleted: {path}");
        }
        return Task.FromResult($"⚠️ Directory not found: {path}");
    }

    [KernelFunction, Description("Create or update a file with content")]
    public async Task<string> CreateOrUpdateFileAsync(
        [Description("File path with name and extension")] string filePath,
        [Description("Content to write into the file")] string content)
    {
        var directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        await File.WriteAllTextAsync(filePath, content);
        return $"📄 File created/updated: {filePath}";
    }

    [KernelFunction, Description("Delete a file")]
    public Task<string> DeleteFileAsync(
        [Description("Path of the file to delete")] string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            return Task.FromResult($"🗑️ File deleted: {filePath}");
        }
        return Task.FromResult($"⚠️ File not found: {filePath}");
    }

    [KernelFunction, Description("Read the contents of a file")]
    public async Task<string> ReadFileAsync(
        [Description("Path of the file to read")] string filePath)
    {
        if (File.Exists(filePath))
        {
            var content = await File.ReadAllTextAsync(filePath);
            return $"📖 File content of {filePath}:\n{content}";
        }
        return $"⚠️ File not found: {filePath}";
    }
}

