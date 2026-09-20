using System.IO;
using System.Text.Json;
using Xunit;

namespace PdfEditorApp.Plugins.MusicPlayer.Tests;

public class MusicPlayerManifestTests
{
    [Fact]
    public void Manifest_ExistsAndHasRequiredFields()
    {
        var manifestPath = Path.Combine(AppContext.BaseDirectory, "plugin.json");
        // Fallback to project directory if not copied
        if (!File.Exists(manifestPath))
        {
            manifestPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "plugin.json"));
        }

        Assert.True(File.Exists(manifestPath), $"plugin.json should exist at {manifestPath}");

        var json = File.ReadAllText(manifestPath);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        Assert.Equal("frypdf.overlay.musicplayer", root.GetProperty("id").GetString());
        Assert.Equal("Music Player", root.GetProperty("name").GetString());
        Assert.Equal("MusicPlayerPlugin.dll", root.GetProperty("entryPoint").GetString());
        Assert.True(root.TryGetProperty("version", out var versionElem));
        Assert.False(string.IsNullOrWhiteSpace(versionElem.GetString()));
    }
}
