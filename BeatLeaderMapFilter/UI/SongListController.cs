using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BeatLeaderMapFilter.UI
{
    [HotReload(RelativePathToLayout = @"UI\BSML\SongList.bsml")]
    [ViewDefinition("BeatLeaderMapFilter.UI.BSML.SongList.bsml")]
    class SongListController : BSMLAutomaticViewController
    {
    }
    
}
