using System;
using Core.MVP;
using UnityEngine;

namespace Views
{
    public class MainView : MonoBehaviour, IView<MainViewData>
    {
        public Action<MainViewData> OnViewDataChanged { get; set; }

        [SerializeField] private SkinViewController skinViewController;

        public void Initialize(MainViewData data)
        {
            skinViewController.PopulateElements(data.SkinsData);
        }

        public void UpdateView(MainViewData data)
        {
            throw new NotImplementedException();
        }

    }
}