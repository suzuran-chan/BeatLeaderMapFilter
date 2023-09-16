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

        //public override int GetHashCode()
        //{
        //    return SongName.GetHashCode() ^
        //            MapHash.GetHashCode() ^
        //            Difficulty.GetHashCode();
        //}

        //public override bool Equals(object obj)
        //{
        //    MapData other = obj as MapData;
        //    if (other == null) return false;

        //    return this.SongName == other.SongName &&
        //            this.MapHash == other.MapHash &&
        //            this.Difficulty == other.Difficulty;
        //}
    }
}
