using System;
using PdfEditorApp.Plugins.MusicPlayer;
using Xunit;

namespace PdfEditorApp.Plugins.MusicPlayer.Tests;

public class TrackViewModelTests
{
    [Fact]
    public void Constructor_InitializesPropertiesCorrectly()
    {
        var track = new TrackViewModel(
            "/music/song.mp3",
            "Midnight City",
            "M83",
            "Hurry Up, We're Dreaming",
            TimeSpan.FromSeconds(243),
            coverArt: null,
            trackNumber: 5,
            isFavorite: true);

        Assert.Equal("/music/song.mp3", track.FilePath);
        Assert.Equal("Midnight City", track.Title);
        Assert.Equal("M83", track.Artist);
        Assert.Equal("Hurry Up, We're Dreaming", track.Album);
        Assert.Equal(TimeSpan.FromSeconds(243), track.Duration);
        Assert.Equal("4:03", track.DurationDisplay);
        Assert.Equal(5, track.TrackNumber);
        Assert.Equal("05", track.TrackNumberDisplay);
        Assert.True(track.IsFavorite);
        Assert.Equal("Heart", track.FavoriteIconKind);
        Assert.Equal("MP3", track.FileExtension);
    }

    [Fact]
    public void FavoriteToggle_UpdatesIconKind()
    {
        var track = new TrackViewModel(
            "/music/song.flac",
            "Track 1",
            "Artist",
            "Album",
            TimeSpan.FromMinutes(3),
            coverArt: null,
            trackNumber: 0,
            isFavorite: false);

        Assert.False(track.IsFavorite);
        Assert.Equal("HeartOutline", track.FavoriteIconKind);
        Assert.Equal("•", track.TrackNumberDisplay);
        Assert.Equal("FLAC", track.FileExtension);

        track.IsFavorite = true;
        Assert.True(track.IsFavorite);
        Assert.Equal("Heart", track.FavoriteIconKind);
    }
}
