using BeatLeaderMapFilter.Path;
using BeatLeaderMapFilter.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BeatLeaderMapFilter.Utilities
{
    public class Playlist
    {
        public string playlistTitle { get; set; }
        public List<Songs> songs { get; set; }
        public string playlistAuthor { get; set; }
        public string image { get; set; }
    }

    public class Songs
    {
        public string songName { get; set; }
        public List<Difficulties> difficulties { get; set; }
        public string hash { get; set; }
    }

    public class Difficulties
    {
        public string name { get; set; }
        public string characteristic { get; set; }
    }

    internal class PlaylistMaker
    {
        public async Task MakePlaylist()
        {
            string _outputPath;
            string songName = "";
            string hash;
            string name = "";
            string characteristic = "";
            string _jsonFinish;

            BeatLeaderMapsDataGetter mapdata = new BeatLeaderMapsDataGetter();
            string jsonMapData = await mapdata.BeatLeaderApiRequest();

            FileNameGetter filename = new FileNameGetter();
            string playlistName = filename.GetPlayListFileName();

            if (Directory.Exists(BSPath.BeatLeaderMapFilterFolderPath))
            {
                _outputPath = System.IO.Path.Combine(BSPath.BeatLeaderMapFilterFolderPath, $"{playlistName}.bplist");
            }
            else
            {
                _outputPath = System.IO.Path.Combine(BSPath.PlaylistsPath, $"{playlistName}.bplist");
            }

            Playlist playlistEdit = new Playlist();
            playlistEdit.playlistTitle = playlistName;
            playlistEdit.playlistAuthor = "BeatLeaderMapFilter";
            playlistEdit.image = GetCoverImage();
            Console.WriteLine(playlistEdit.image);
            List<Songs> songsList = new List<Songs>();

            dynamic jsonDynamic = JsonConvert.DeserializeObject(jsonMapData);
            foreach (var mapData in jsonDynamic)
            {
                songName = mapData._songName;
                hash = mapData._mapHash;
                name = mapData._difficulty;
                characteristic = mapData._characteristic;

                Songs songs = new Songs();
                List<Difficulties> difficultiesList = new List<Difficulties>();
                Difficulties difficulties = new Difficulties();

                difficulties.name = name;
                difficulties.characteristic = characteristic;
                difficultiesList.Add(difficulties);
                songs.songName = songName;
                songs.difficulties = difficultiesList;
                songs.hash = hash;

                Console.WriteLine(songs);
                songsList.Add(songs);
            }

            playlistEdit.songs = songsList;

            _jsonFinish = JsonConvert.SerializeObject(playlistEdit, Newtonsoft.Json.Formatting.Indented);

            StreamWriter wr = new StreamWriter(_outputPath, false);
            wr.WriteLine(_jsonFinish);
            wr.Close();
        }

        private static string SetCaracteristic(string characteristic, MapData mapData)
        {
            if (mapData.Difficulty.Contains("Standard"))
            {
                characteristic = "Standard";
            }
            else if (mapData.Difficulty.Contains("NoArrow"))
            {
                characteristic = "NoArrow";
            }
            else if (mapData.Difficulty.Contains("SingleSaber"))
            {
                characteristic = "SingleSaber";
            }

            return characteristic;
        }

        private static string SetDifficulty(string name, MapData mapData)
        {
            if (mapData.Difficulty.Contains("ExpertPlus"))
            {
                name = "expertPlus";
            }
            else if (mapData.Difficulty.Contains("Expert"))
            {
                name = "expert";
            }
            else if (mapData.Difficulty.Contains("Hard"))
            {
                name = "hard";
            }
            else if (mapData.Difficulty.Contains("Normal"))
            {
                name = "normal";
            }
            else if (mapData.Difficulty.Contains("Easy"))
            {
                name = "easy";
            }

            return name;
        }

        public string GetCoverImage()
        {
            try
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"BeatLeaderMapFilter.Resources.BeatLeaderMapFilterImage.png"))
                {
                    var b = new byte[stream.Length];
                    stream.Read(b, 0, (int)stream.Length);

                    return Convert.ToBase64String(b);
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.Message + "\n" + "Fail to complete GetCoverImage method");
            }

            return "";
        }


    }
}
