//using BeatLeaderMapFilter.Configuration;
//using BeatLeaderMapFilter.Path;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Xml;

//namespace BeatLeaderMapFilter.Utilities
//{
//    public class Playlist
//    {
//        public string playlistTitle { get; set; }
//        public List<Songs> songs { get; set; }
//        public string playlistAuthor { get; set; }
//        public string image { get; set; }
//    }

//    public class Songs
//    {
//        public string songName { get; set; }
//        public List<Difficulties> difficulties { get; set; }
//        public string hash { get; set; }
//    }

//    public class Difficulties
//    {
//        public string name { get; set; }
//        public string characteristic { get; set; }
//        public string pPDiff { get; set; }
//    }

//    internal class PlaylistMaker
//    {
//        // コンストラクタや他のメンバーは省略

//        public void MakePlaylist(Dictionary<MapData, PPData> mapDataList)
//        {
//            // プレイリスト名を生成
//            string playlistName = GeneratePlaylistName();

//            // 出力パスを設定
//            string _outputPath = GetOutputPath(playlistName);



//            // プレイリストオブジェクトを生成
//            Playlist playlistEdit = CreatePlaylistObject(playlistName);

//            // 曲情報をプレイリストに追加
//            List<Songs> songsList = AddSongsToPlaylist(mapDataList);

//            // プレイリスト情報をJSONにシリアライズして保存
//            string _jsonFinish = SerializeAndSavePlaylist(playlistEdit, _outputPath, songsList);
//        }

//        private string GeneratePlaylistName()
//        {
//            DateTime dt = DateTime.Now;
//            return dt.ToString("yyyyMMddHHmm") + "-RR" + PluginConfig.Instance.RankRange.ToString() +
//                "-PF" + PluginConfig.Instance.PPFilter + "-YPR" + PluginConfig.Instance.YourPageRange +
//                "-OPR" + PluginConfig.Instance.OthersPageRange + "-" + (PluginConfig.Instance.GlobalMode ? "Global" : "Local");
//        }

//        private string GetOutputPath(string playlistName)
//        {
//            if (Directory.Exists(BSPath.GetNearRankModFolderPath) && PluginConfig.Instance.FolderMode)
//            {
//                return System.IO.Path.Combine(BSPath.GetNearRankModFolderPath, $"{playlistName}.bplist");
//            }
//            else
//            {
//                return System.IO.Path.Combine(BSPath.PlaylistsPath, $"{playlistName}.bplist");
//            }
//        }

//        private Playlist CreatePlaylistObject(string playlistName)
//        {
//            Playlist playlistEdit = new Playlist();
//            playlistEdit.playlistTitle = playlistName;
//            playlistEdit.playlistAuthor = "GetNearRankMod";
//            playlistEdit.image = GetCoverImage();
//            return playlistEdit;
//        }

//        private List<Songs> AddSongsToPlaylist(Dictionary<MapData, PPData> mapDataList)
//        {
//            List<Songs> songsList = new List<Songs>();

//            foreach (KeyValuePair<MapData, PPData> mapDataAndPPDiff in mapDataList)
//            {
//                // 曲情報を生成してリストに追加
//                Songs song = CreateSong(mapDataAndPPDiff);
//                songsList.Add(song);
//            }

//            return songsList;
//        }

//        private Songs CreateSong(KeyValuePair<MapData, PPData> mapDataAndPPDiff)
//        {
//            Songs song = new Songs();
//            song.songName = mapDataAndPPDiff.Key.SongName;
//            song.hash = mapDataAndPPDiff.Key.MapHash;
//            song.difficulties = CreateDifficultiesList(mapDataAndPPDiff);
//            return song;
//        }

//        private List<Difficulties> CreateDifficultiesList(KeyValuePair<MapData, PPData> mapDataAndPPDiff)
//        {
//            List<Difficulties> difficultiesList = new List<Difficulties>();
//            Difficulties difficulties = new Difficulties();
//            difficulties.name = SetDifficulty(mapDataAndPPDiff.Key);
//            difficulties.characteristic = SetCaracteristic(mapDataAndPPDiff.Key);
//            difficulties.pPDiff = mapDataAndPPDiff.Value.PP.ToString();
//            difficultiesList.Add(difficulties);
//            return difficultiesList;
//        }

//        private string SerializeAndSavePlaylist(Playlist playlistEdit, string outputPath, List<Songs> songsList)
//        {
//            playlistEdit.songs = songsList;
//            string _jsonFinish = JsonConvert.SerializeObject(playlistEdit, Formatting.Indented);
//            StreamWriter wr = new StreamWriter(outputPath, false);
//            wr.WriteLine(_jsonFinish);
//            wr.Close();
//            return _jsonFinish;
//        }

//        // その他のメソッドやフィールドは省略
//    }

//}
