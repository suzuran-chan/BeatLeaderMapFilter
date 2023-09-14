using BeatLeaderMapFilter.Path;
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
            Console.WriteLine(Directory.CreateDirectory(BSPath.BeatLeaderMapFilterFolderPath));
            if (Directory.Exists(BSPath.BeatLeaderMapFilterFolderPath)) return;

            Directory.CreateDirectory(BSPath.BeatLeaderMapFilterFolderPath);
        }
    }
}