using BeatSaberMarkupLanguage;
using HMUI;
using Zenject;
using System;
using ModestTree;

namespace BeatLeaderMapFilter.UI
{
    public class BLMFFlowCoordinator : FlowCoordinator
    {
        internal FlowCoordinator _parentFlow;
        private FilterView _filterView;
        private SongListController _songlist;
        public void Awake()
        {
            if (_filterView == null)
            {
                _filterView = BeatSaberUI.CreateViewController<FilterView>();

            }
            if (_songlist == null)
            {
                _songlist = BeatSaberUI.CreateViewController<SongListController>();

            }


            _parentFlow = BeatSaberUI.MainFlowCoordinator.YoungestChildFlowCoordinatorOrSelf();
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {

            SetTitle("Beat Leader Map Filter");

            showBackButton = true;

            ProvideInitialViewControllers(_songlist, _filterView);

        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            _parentFlow?.DismissFlowCoordinator(this);
        }
    }
}