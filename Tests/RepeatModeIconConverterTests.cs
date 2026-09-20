using System.Globalization;
using Material.Icons;
using PdfEditorApp.Plugins.MusicPlayer;
using Xunit;

namespace PdfEditorApp.Plugins.MusicPlayer.Tests;

public class RepeatModeIconConverterTests
{
    [Theory]
    [InlineData(RepeatMode.Off, MaterialIconKind.RepeatOff)]
    [InlineData(RepeatMode.RepeatOne, MaterialIconKind.RepeatOnce)]
    [InlineData(RepeatMode.RepeatAll, MaterialIconKind.RepeatVariant)]
    public void Convert_MapsRepeatModesToCorrectIcons(RepeatMode mode, MaterialIconKind expectedKind)
    {
        var converter = RepeatModeIconConverter.Instance;
        var result = converter.Convert(mode, typeof(MaterialIconKind), null, CultureInfo.InvariantCulture);

        Assert.Equal(expectedKind, result);
    }

    [Fact]
    public void Convert_InvalidValue_DefaultsToRepeatOff()
    {
        var converter = RepeatModeIconConverter.Instance;
        var result = converter.Convert("invalid", typeof(MaterialIconKind), null, CultureInfo.InvariantCulture);

        Assert.Equal(MaterialIconKind.RepeatOff, result);
    }
}
