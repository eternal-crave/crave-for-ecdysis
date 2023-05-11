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


        private void OnEnable()
        {
            skinViewController.OnSkinSelect += skinOverview.SetData;
        }

        private void OnDisable()
        {
            skinViewController.OnSkinSelect -= skinOverview.SetData;
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