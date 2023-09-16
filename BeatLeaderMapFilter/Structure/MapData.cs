namespace BeatLeaderMapFilter.Structure
{
    public class MapData
    {
        public string _songName;
        public string _mapHash;
        public string _difficulty;
        public string _characteristic;


        public MapData(string songName, string mapHash, string difficulty, string characteristic)
        {
            _songName = songName;
            _mapHash = mapHash;
            _difficulty = difficulty;
            _characteristic = characteristic;
        }

        internal string SongName => _songName;
        internal string MapHash => _mapHash;
        internal string Difficulty => _difficulty;
        internal string Characteristic => _characteristic;
    }
}
