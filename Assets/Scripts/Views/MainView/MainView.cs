using System;
using Components;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class MainView: MBView<MainViewData>
    {
        [SerializeField] private SkinViewController skinViewController;
        [SerializeField] private Button unlockRandomSkinButton;


        private void OnEnable()
        {
            unlockRandomSkinButton.onClick.AddListener(OnRandomButtonClick);
        }

        private void OnDisable()
        {
            unlockRandomSkinButton.onClick.RemoveListener(OnRandomButtonClick);
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

        private void OnApplicationQuit()
        {
            Close();
        }
    }
}