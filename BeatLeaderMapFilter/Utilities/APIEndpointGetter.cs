using BeatLeaderMapFilter.Configuration;
using System;

namespace BeatLeaderMapFilter.Utilities
{
    internal class APIEndpointGetter
    {
        public string GetRequestUrl()
        {
            string endpointURL = "https://api.beatleader.xyz/leaderboards?page=1&sortBy=timestamp&order=desc";

            if (PluginConfig.Instance.Search != "")
            {
                endpointURL = endpointURL + "&search=" + PluginConfig.Instance.Search;
            }
            if (PluginConfig.Instance.Type == "All maps")
            {
                endpointURL = endpointURL + "&type=all";
            }
            else
            {
                string type = GetTypeString(PluginConfig.Instance.Type);
                endpointURL = endpointURL + "&type=" + type;

                if (PluginConfig.Instance.Category != "None")
                {
                    int category = GetCategoryNumber(PluginConfig.Instance.Category);
                    endpointURL = endpointURL + "&mapType=" + category;
                }

                if (PluginConfig.Instance.Stars == true)
                {
                    endpointURL = endpointURL + "&stars_from=" + PluginConfig.Instance.StarsFrom + "&stars_to=" + PluginConfig.Instance.StarsTo;
                }
                if (PluginConfig.Instance.AccRating == true)
                {
                    endpointURL = endpointURL + "&accrating_from=" + PluginConfig.Instance.AccRatingFrom + "&accrating_to=" + PluginConfig.Instance.AccRatingTo;
                }
                if (PluginConfig.Instance.PassRating == true)
                {
                    endpointURL = endpointURL + "&passrating_from=" + PluginConfig.Instance.PassRatingFrom + "&passrating_to=" + PluginConfig.Instance.PassRatingTo;
                }
                if (PluginConfig.Instance.TechRating == true)
                {
                    endpointURL = endpointURL + "&techrating_from=" + PluginConfig.Instance.TechRatingFrom + "&techrating_to=" + PluginConfig.Instance.TechRatingTo;
                }
            }
            endpointURL = endpointURL + "&count=" + PluginConfig.Instance.MapsCount;
            Console.WriteLine(endpointURL);

            return endpointURL;
        }

        public string GetTypeString(string type)
        {
            if (type == "Nominated")
            {
                return "nominated";
            }
            else if (type == "Qualified")
            {
                return "qualified";
            }
            else if (type == "Ranked")
            {
                return "ranked";
            }
            else
            {
                return string.Empty;
            }
        }

        public int GetCategoryNumber(string category)
        {
            if (category == "Acc")
            {
                return 1;
            } 
            else if (category == "Tech")
            {
                return 2;
            }
            else if (category == "Midspeed")
            {
                return 4;
            }
            else if (category == "Speed")
            {
                return 8;
            } else
            {
                return  -1;
            }
        }
    }
}
