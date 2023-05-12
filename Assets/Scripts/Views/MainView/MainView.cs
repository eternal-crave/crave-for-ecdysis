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
            skinViewController.PopulateElements(data.SkinDataCollections);
        }
    }
}