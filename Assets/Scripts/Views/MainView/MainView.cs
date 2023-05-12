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
        private MainViewData _viewData;


        private void OnEnable()
        {
            skinViewController.OnSkinSelect += skinOverview.SetData;
            OnClose += () => OnViewClose?.Invoke(_viewData); // Don't unsubscribe cuz it happens automatically on close
        }

        private void OnDisable()
        {
            skinViewController.OnSkinSelect -= skinOverview.SetData;
        }

        private void SetData(MainViewData data)
        {
            _viewData = data;
            skinViewController.PopulateElements(data.SkinDataCollections);
        }
        
        public override void UpdateView(MainViewData data)
        {
            SetData(data);
        }

        private void OnApplicationQuit()
        {
            Close();
        }

        public override void Initialize(MainViewData data)
        {
            Activate();
        }
    }
}