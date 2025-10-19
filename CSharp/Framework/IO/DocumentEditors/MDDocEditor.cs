using System;
using System.IO;
using System.Text;

namespace VaultSharp.Framework.IO.DocumentEditors
{
  public class MDDocEditor
  {
    private readonly string _filePath;
    private string _content;
    private bool _isLoaded;

    public string FilePath => _filePath;
    public bool IsLoaded => _isLoaded;

    /// Creates a new markdown document editor for the specified file.
    /// filePath = Full path to the markdown file
    public MDDocEditor(string filePath)
    {
      if (string.IsNullOrWhiteSpace(filePath))
      {
        throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
      }

      _filePath = filePath;
      _content = string.Empty;
      _isLoaded = false;
    }

    /// Loads the markdown file content from disk.
    /// Must be called before GetContent() or SetContent().
    /// returns True if file was loaded successfully, false otherwise
    public bool Load()
    {
      try
      {
        if (!File.Exists(_filePath))
        {
          Console.WriteLine($"Warning: File does not exist: {_filePath}");
          _content = string.Empty;
          _isLoaded = true;
          return false;
        }

        _content = File.ReadAllText(_filePath, Encoding.UTF8);
        _isLoaded = true;
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error loading file {_filePath}: {ex.Message}");
        _content = string.Empty;
        _isLoaded = false;
        return false;
      }
    }

    /// Gets the current markdown content as a string.
    /// returns The markdown content, or empty string if not loaded
    public string GetContent()
    {
      if (!_isLoaded)
      {
        Console.WriteLine("Warning: Content accessed before Load() was called");
      }
      return _content;
    }

    /// Sets the markdown content to a new string.
    /// Changes are held in memory until Save() is called.
    public void SetContent(string newContent)
    {
      _content = newContent ?? string.Empty;
      _isLoaded = true;
    }

    /// Saves the current content back to the markdown file, overwriting it.
    /// Creates the file if it doesn't exist.
    /// returns True if save was successful, false otherwise
    public bool Save()
    {
      try
      {
        // Ensure directory exists
        string? directory = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
          Directory.CreateDirectory(directory);
        }

        // Write content to file
        File.WriteAllText(_filePath, _content, Encoding.UTF8);
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error saving file {_filePath}: {ex.Message}");
        return false;
      }
    }

    /// Convenience method: Load, modify content, and save in one operation.
    /// modifyFunc = Function that takes current content and returns modified content
    /// returns True if operation was successful, false otherwise
    public bool LoadModifySave(Func<string, string> modifyFunc)
    {
      if (!Load())
      {
        return false;
      }

      try
      {
        _content = modifyFunc(_content);
        return Save();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error modifying content: {ex.Message}");
        return false;
      }
    }
  }
}
