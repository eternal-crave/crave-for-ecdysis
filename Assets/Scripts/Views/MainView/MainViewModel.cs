using System;
using System.Collections.Generic;
using System.Linq;
using Core.MVP;
using SkinData;
using UnityEngine;

namespace Views
{
    public class MainViewModel: IModel<MainViewData>
    {
        public Action<MainViewData> OnDataChanged { get; set; }
        private List<SkinCollection> _skinDataCollections;
        public void Initialize()
        {
            _skinDataCollections = Resources.LoadAll<SkinCollection>("SkinData/Collections").ToList();
        }

        public void UpdateData(MainViewData viewData)
        {
            _skinDataCollections = viewData.SkinDataCollections;
        }

        public MainViewData GetData()
        {
            return new MainViewData(new List<SkinCollection>(_skinDataCollections));
        }
    }
}