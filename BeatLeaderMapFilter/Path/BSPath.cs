namespace BeatLeaderMapFilter.Path
{
    internal static class BSPath
    {
        // internal static string PlaylistsPath = @".\Playlists";
        internal static string BeatLeaderMapFilterFolderPath = System.IO.Path.Combine(PlaylistsPath, PluginConfig.Instance.FolderName);
    }
}