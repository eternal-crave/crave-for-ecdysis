using System;
using Components;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class MainView: MBView<MainViewData>
    {
        [SerializeField] private SkinViewController skinViewController;
        [SerializeField] private SkinOverview skinOverview;
        [SerializeField] private Button unlockRandomSkinButton;


        private void OnEnable()
        {
            unlockRandomSkinButton.onClick.AddListener(OnRandomButtonClick);
            skinViewController.OnSkinSelect += skinOverview.SetData;
        }

        private void OnDisable()
        {
            unlockRandomSkinButton.onClick.RemoveListener(OnRandomButtonClick);
            skinViewController.OnSkinSelect -= skinOverview.SetData;
        }

        private void OnRandomButtonClick()
        {
            skinViewController.UnlockRandomSkin();
        }

        public override void Initialize(MainViewData data)
        {
            //TODO change to work with multiple skin data collections
            skinViewController.PopulateElements(data.SkinDataCollections[0].Skins);
        }

        public override void UpdateView(MainViewData data)
        {
            throw new System.NotImplementedException();
        }
    }
}