using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;

using BeatSaberMarkupLanguage.MenuButtons;
using HMUI;
using System;
using UnityEngine;
using UnityEngine.UI;


namespace BeatLeaderMapFilter.UI
{
    public class Manager
    {
        public static void Init()
        {
            MenuButtons.instance.RegisterButton(new MenuButton("Beat Leader Map Filter", "Filter maps and Generate playlists", ShowFlow, true));
        }

        internal static FlowCoordinator _parentFlow { get; private set; }
        internal static BLMFFlowCoordinator _flow { get; private set; }
        internal static Button.ButtonClickedEvent goToSongSelect { get; private set; } = null;

        public static void ShowFlow() => ShowFlow(false);
        private static void ShowFlow(bool immediately)
        {
            if (_flow == null)
                _flow = BeatSaberUI.CreateFlowCoordinator<BLMFFlowCoordinator>();

            _parentFlow = BeatSaberUI.MainFlowCoordinator.YoungestChildFlowCoordinatorOrSelf();

            BeatSaberUI.PresentFlowCoordinator(_parentFlow, _flow, immediately: immediately);
        }

    }
}