using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BeatSaberMarkupLanguage.Parser;
using HMUI;
using IPA.Utilities;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using System.Threading.Tasks;

namespace BeatLeaderMapFilter.UI
{
    [HotReload(RelativePathToLayout = @"UI\BSML\FilterView.bsml")]
    [ViewDefinition("BeatLeaderMapFilter.UI.BSML.FilterView.bsml")]
    class FilterView : BSMLAutomaticViewController, INotifyPropertyChanged
    {
        [UIValue("type-list-options")]
        private List<object> typeListOptions = new object[] { "All maps", "Nominated", "Qualified", "Ranked" }.ToList();

        [UIValue("type-list-choice")]
        private string typelistChoice = "All maps";

        [UIValue("category-list-options")]
        private List<object> categoryListOptions = new object[] { "None", "Acc", "Tech", "Midspeed", "Speed" }.ToList();

        [UIValue("category-list-choice")]
        private string categorylistChoice = "None";
    }

}