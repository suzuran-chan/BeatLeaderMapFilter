using BeatLeaderMapFilter.Utilities;
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
    public class FilterView : BSMLAutomaticViewController, INotifyPropertyChanged
    {
        public static FilterView Instance { get; private set; } = new FilterView();


        public void SyncWithPluginConfig(string propetyName)
        {
            System.Reflection.PropertyInfo[] thisPropetyInfo = typeof(FilterView).GetProperties();
            foreach (var propertyInfo in thisPropetyInfo)
            {
                if (propertyInfo.Name != propetyName) continue;

                NotifyPropertyChanged(propetyName);
                break;
            }
        }

        [UIValue("Search")]
        public string Search
        {
            get => Configuration.PluginConfig.Instance.Search;
            set
            {
                //Console.WriteLine($"Setting Search property to: {value}");
                Configuration.PluginConfig.Instance.Search = value;
                Console.WriteLine("setテスト");
               Console.WriteLine(Configuration.PluginConfig.Instance.Search);
                NotifyPropertyChanged(nameof(Search));
            }
        }

        [UIValue("TypeList")]
        private List<object> TypeList = new object[] { "All maps", "Nominated", "Qualified", "Ranked" }.ToList();

        [UIValue("Type")]
        public string Type
        {
            get => Configuration.PluginConfig.Instance.Type;
            set
            {
                Configuration.PluginConfig.Instance.Type = value;
                NotifyPropertyChanged(nameof(Type));
            }
        }

        [UIValue("CategoryList")]
        private List<object> CategoryList = new object[] { "None", "Acc", "Tech", "Midspeed", "Speed" }.ToList();

        [UIValue("Category")]
        public string Category
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
                Console.WriteLine("setテスト");
                Console.WriteLine(Configuration.PluginConfig.Instance.StarsFrom);
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

        [UIAction("playlistGenerate")]
        private void playlistButtonClicked()
        {
            Console.WriteLine("Playlist Button was clicked!");
            PlaylistMaker playlistMaker = new PlaylistMaker();
            playlistMaker.MakePlaylist();
            SongCore.Loader.Instance.RefreshSongs(false);
        }
    }

}