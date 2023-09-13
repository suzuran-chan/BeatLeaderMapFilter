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
            get => Configuration.PluginConfig.Instance.Search;
            set
            {
                Configuration.PluginConfig.Instance.Search = value;
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
            get => Configuration.PluginConfig.Instance.Type;
            set
            {
                Configuration.PluginConfig.Instance.Type = value;
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
            get => Configuration.PluginConfig.Instance.Category;
            set
            {
                Configuration.PluginConfig.Instance.Category = value;
                NotifyPropertyChanged(nameof(Category));
            }
        }

        [UIValue("Stars")]
        public bool Stars
        {
            get => Configuration.PluginConfig.Instance.Stars;
            set
            {
                Configuration.PluginConfig.Instance.Stars = value;
                NotifyPropertyChanged(nameof(Stars));
            }
        }

        [UIValue("StarsFrom")]
        public float StarsFrom
        {
            get => Configuration.PluginConfig.Instance.StarsFrom;
            set
            {
                Configuration.PluginConfig.Instance.StarsFrom = value;
                NotifyPropertyChanged(nameof(StarsFrom));
            }
        }
        
        [UIValue("StarsTo")]
        public float StarsTo
        {
            get => Configuration.PluginConfig.Instance.StarsTo;
            set
            {
                Configuration.PluginConfig.Instance.StarsTo = value;
                NotifyPropertyChanged(nameof(StarsTo));
            }
        }

        [UIValue("AccRating")]
        public bool AccRating
        {
            get => Configuration.PluginConfig.Instance.AccRating;
            set
            {
                Configuration.PluginConfig.Instance.AccRating = value;
                NotifyPropertyChanged(nameof(AccRating));
            }
        }

        [UIValue("AccRatingFrom")]
        public float AccRatingFrom
        {
            get => Configuration.PluginConfig.Instance.AccRatingFrom;
            set
            {
                Configuration.PluginConfig.Instance.AccRatingFrom = value;
                NotifyPropertyChanged(nameof(AccRatingFrom));
            }
        }

        [UIValue("AccRatingTo")]
        public float AccRatingTo
        {
            get => Configuration.PluginConfig.Instance.AccRatingTo;
            set
            {
                Configuration.PluginConfig.Instance.AccRatingTo = value;
                NotifyPropertyChanged(nameof(AccRatingTo));
            }
        }

        [UIValue("PassRating")]
        public bool PassRating
        {
            get => Configuration.PluginConfig.Instance.PassRating;
            set
            {
                Configuration.PluginConfig.Instance.PassRating = value;
                NotifyPropertyChanged(nameof(PassRating));
            }
        }

        [UIValue("PassRatingFrom")]
        public float PassRatingFrom
        {
            get => Configuration.PluginConfig.Instance.PassRatingFrom;
            set
            {
                Configuration.PluginConfig.Instance.PassRatingFrom = value;
                NotifyPropertyChanged(nameof(PassRatingFrom));
            }
        }

        [UIValue("PassRatingTo")]
        public float PassRatingTo
        {
            get => Configuration.PluginConfig.Instance.PassRatingTo;
            set
            {
                Configuration.PluginConfig.Instance.PassRatingTo = value;
                NotifyPropertyChanged(nameof(PassRatingTo));
            }
        }

        [UIValue("TechRating")]
        public bool TechRating
        {
            get => Configuration.PluginConfig.Instance.TechRating;
            set
            {
                Configuration.PluginConfig.Instance.TechRating = value;
                NotifyPropertyChanged(nameof(TechRating));
            }
        }

        [UIValue("TechRatingFrom")]
        public float TechRatingFrom
        {
            get => Configuration.PluginConfig.Instance.TechRatingFrom;
            set
            {
                Configuration.PluginConfig.Instance.TechRatingFrom = value;
                NotifyPropertyChanged(nameof(TechRatingFrom));
            }
        }
        
        [UIValue("TechRatingTo")]
        public float TechRatingTo
        {
            get => Configuration.PluginConfig.Instance.TechRatingTo;
            set
            {
                Configuration.PluginConfig.Instance.TechRatingTo = value;
                NotifyPropertyChanged(nameof(TechRatingTo));
            }
        }

        [UIValue("MapsCount")]
        public int MapsCount
        {
            get => Configuration.PluginConfig.Instance.MapsCount;
            set
            {
                Configuration.PluginConfig.Instance.MapsCount = value;
                NotifyPropertyChanged(nameof(MapsCount));
            }
        }
    }

}