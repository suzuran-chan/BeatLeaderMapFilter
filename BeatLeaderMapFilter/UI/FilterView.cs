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
        [UIValue("Search")]
        public string Search
        {
            get => PluginConfig.Instance.Search;
            set
            {
                PluginConfig.Instance.Search = value;
                NotifyPropertyChanged(nameof(Search));
            }
        }

        [UIValue("type-list-options")]
        private List<object> typeListOptions = new object[] { "All maps", "Nominated", "Qualified", "Ranked" }.ToList();

        // [UIValue("type-list-choice")]
        // private string typelistChoice = "All maps";
        [UIValue("type-list-choice")]
        public string typelistChoice
        {
            get => PluginConfig.Instance.Type;
            set
            {
                PluginConfig.Instance.Type = value;
                NotifyPropertyChanged(nameof(Type));
            }
        }

        [UIValue("category-list-options")]
        private List<object> categoryListOptions = new object[] { "None", "Acc", "Tech", "Midspeed", "Speed" }.ToList();

        // [UIValue("category-list-choice")]
        // private string categorylistChoice = "None";
        [UIValue("category-list-choice")]
        public string categorylistChoice
        {
            get => PluginConfig.Instance.Category;
            set
            {
                PluginConfig.Instance.Category = value;
                NotifyPropertyChanged(nameof(Category));
            }
        }

        [UIValue("Stars")]
        public bool Stars
        {
            get => PluginConfig.Instance.Stars;
            set
            {
                PluginConfig.Instance.Stars = value;
                NotifyPropertyChanged(nameof(Stars));
            }
        }

        [UIValue("StarsFrom")]
        public float StarsFrom
        {
            get => PluginConfig.Instance.StarsFrom;
            set
            {
                PluginConfig.Instance.StarsFrom = value;
                NotifyPropertyChanged(nameof(StarsFrom));
            }
        }
        
        [UIValue("StarsTo")]
        public float StarsTo
        {
            get => PluginConfig.Instance.StarsTo;
            set
            {
                PluginConfig.Instance.StarsTo = value;
                NotifyPropertyChanged(nameof(StarsTo));
            }
        }

        [UIValue("AccRating")]
        public bool AccRating
        {
            get => PluginConfig.Instance.AccRating;
            set
            {
                PluginConfig.Instance.AccRating = value;
                NotifyPropertyChanged(nameof(AccRating));
            }
        }

        [UIValue("AccRatingFrom")]
        public float AccRatingFrom
        {
            get => PluginConfig.Instance.AccRatingFrom;
            set
            {
                PluginConfig.Instance.AccRatingFrom = value;
                NotifyPropertyChanged(nameof(AccRatingFrom));
            }
        }

        [UIValue("AccRatingTo")]
        public float AccRatingTo
        {
            get => PluginConfig.Instance.AccRatingTo;
            set
            {
                PluginConfig.Instance.AccRatingTo = value;
                NotifyPropertyChanged(nameof(AccRatingTo));
            }
        }

        [UIValue("PassRating")]
        public bool PassRating
        {
            get => PluginConfig.Instance.PassRating;
            set
            {
                PluginConfig.Instance.PassRating = value;
                NotifyPropertyChanged(nameof(PassRating));
            }
        }

        [UIValue("PassRatingFrom")]
        public float PassRatingFrom
        {
            get => PluginConfig.Instance.PassRatingFrom;
            set
            {
                PluginConfig.Instance.PassRatingFrom = value;
                NotifyPropertyChanged(nameof(PassRatingFrom));
            }
        }

        [UIValue("PassRatingTo")]
        public float PassRatingTo
        {
            get => PluginConfig.Instance.PassRatingTo;
            set
            {
                PluginConfig.Instance.PassRatingTo = value;
                NotifyPropertyChanged(nameof(PassRatingTo));
            }
        }

        [UIValue("TechRating")]
        public bool TechRating
        {
            get => PluginConfig.Instance.TechRating;
            set
            {
                PluginConfig.Instance.TechRating = value;
                NotifyPropertyChanged(nameof(TechRating));
            }
        }

        [UIValue("TechRatingFrom")]
        public float TechRatingFrom
        {
            get => PluginConfig.Instance.TechRatingFrom;
            set
            {
                PluginConfig.Instance.TechRatingFrom = value;
                NotifyPropertyChanged(nameof(TechRatingFrom));
            }
        }
        
        [UIValue("TechRatingTo")]
        public float TechRatingTo
        {
            get => PluginConfig.Instance.TechRatingTo;
            set
            {
                PluginConfig.Instance.TechRatingTo = value;
                NotifyPropertyChanged(nameof(TechRatingTo));
            }
        }

        [UIValue("MapsCount")]
        public int MapsCount
        {
            get => PluginConfig.Instance.MapsCount;
            set
            {
                PluginConfig.Instance.MapsCount = value;
                NotifyPropertyChanged(nameof(MapsCount));
            }
        }
    }

}