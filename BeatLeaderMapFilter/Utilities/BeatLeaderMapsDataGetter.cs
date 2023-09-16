using BeatLeaderMapFilter.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BeatLeaderMapFilter.Utilities
{
    internal class BeatLeaderMapsDataGetter
    {
        public async Task<string> BeatLeaderApiRequest()
        {
            List<MapData> mapDataList = new List<MapData>();

            try
            {
                HttpClient client = new HttpClient();

                APIEndpointGetter endpoint = new APIEndpointGetter();
                string endpointURL = endpoint.GetRequestUrl();

                HttpResponseMessage response = await client.GetAsync(endpointURL);
                string jsonString = await response.Content.ReadAsStringAsync();

                dynamic jsonDynamic = JsonConvert.DeserializeObject(jsonString);

                foreach (var jsonData in jsonDynamic["data"])
                {
                    string songName = JsonConvert.SerializeObject(jsonData["song"]["name"]).Replace("\"", "");
                    string mapHash = JsonConvert.SerializeObject(jsonData["song"]["hash"]).Replace("\"", "");
                    string difficulty = JsonConvert.SerializeObject(jsonData["difficulty"]["difficultyName"]).Replace("\"", "");
                    string characteristic = JsonConvert.SerializeObject(jsonData["difficulty"]["modeName"]).Replace("\"", "");
                    MapData mapData = new MapData(songName, mapHash, difficulty, characteristic);

                    mapDataList.Add(mapData);
                }

                string jsonMapData = JsonConvert.SerializeObject(mapDataList, Formatting.Indented);

                return jsonMapData;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return string.Empty;
            }
        }
    }
}