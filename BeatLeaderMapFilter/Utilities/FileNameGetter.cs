using BeatLeaderMapFilter.Configuration;
using System;

namespace BeatLeaderMapFilter.Utilities
{
    public class FileNameGetter
    {
        public string GetPlayListFileName()
        {
            string playlistName = string.Empty;

            DateTime dt = DateTime.Now;
            playlistName = dt.ToString("yyyyMMddHHmm");

            if (PluginConfig.Instance.Search != "")
            {
                if (PluginConfig.Instance.Search.Length > 15)
                {
                    playlistName = playlistName + "-S" + PluginConfig.Instance.Search.Substring(0, 15) + "...";
                }
                else
                {
                    playlistName = playlistName + "-S" + PluginConfig.Instance.Search;
                }
            }
            if (PluginConfig.Instance.Type == "All maps")
            {
                playlistName = playlistName + "-T" + PluginConfig.Instance.Type;
            }
            else
            {
                playlistName = playlistName + "-T" + PluginConfig.Instance.Type;
                if (PluginConfig.Instance.Category != "")
                {
                    playlistName = playlistName + "-C" + PluginConfig.Instance.Category;
                }

                if (PluginConfig.Instance.Stars == true)
                {
                    playlistName = playlistName + "-SF" + PluginConfig.Instance.StarsFrom + "-ST" + PluginConfig.Instance.StarsTo;
                }
                if (PluginConfig.Instance.AccRating == true)
                {
                    playlistName = playlistName + "-ARF" + PluginConfig.Instance.AccRatingFrom + "-ART" + PluginConfig.Instance.AccRatingTo;
                }
                if (PluginConfig.Instance.PassRating == true)
                {
                    playlistName = playlistName + "-PRF" + PluginConfig.Instance.PassRatingFrom + "-ART" + PluginConfig.Instance.PassRatingTo;
                }
                if (PluginConfig.Instance.TechRating == true)
                {
                    playlistName = playlistName + "-TRF" + PluginConfig.Instance.TechRatingFrom + "-TRT" + PluginConfig.Instance.TechRatingTo;
                }
            }
            playlistName = playlistName + "-MC" + PluginConfig.Instance.MapsCount;

            return playlistName;
        }
    }
}
