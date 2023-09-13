using GetNearRankMod.Path;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BeatLeaderMapFilter.Utilities
{
    internal class FolderMaker
    {
        internal void MakeBeatLeaderMapFilterFolder()
        {
            if (Directory.Exists(BSPath.BeatLeaderMapFilterFolderPath)) return;

            Directory.CreateDirectory(BSPath.BeatLeaderMapFilterFolderPath);
        }
    }
}