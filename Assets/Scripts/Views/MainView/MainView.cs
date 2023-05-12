using System;
using Components;
using Core.MVP;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class MainView: MonoBehaviour, IView<MainViewData>
    {
        public Action<MainViewData> OnViewClose { get; set; }

        [SerializeField] private SkinViewController skinViewController;
        [SerializeField] private SkinOverview skinOverview;
        private MainViewData _viewData;


        private void OnEnable()
        {
            skinViewController.OnSkinSelect += skinOverview.SetData;
        }

        private void OnDisable()
        {
            skinViewController.OnSkinSelect -= skinOverview.SetData;
            OnViewClose?.Invoke(_viewData);
        }

        private void SetData(MainViewData data)
        {
            _viewData = data;
            skinViewController.PopulateElements(data.SkinDataCollections);
        }

        public void UpdateView(MainViewData data)
        {
            SetData(data);
        }
    }
}