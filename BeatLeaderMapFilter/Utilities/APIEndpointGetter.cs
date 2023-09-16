namespace BeatLeaderMapFilter.Utilities
{
    internal class APIEndpointGetter
    {
        public string GetRequestUrl() 
        {
            string baseURL = "https://api.beatleader.xyz/leaderboards?&allTypes=0&allRequirements=0&type=1";



            return baseURL;
        }
    }
}
