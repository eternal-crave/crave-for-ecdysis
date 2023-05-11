using System;
using System.Collections.Generic;
using System.Linq;
using Core.MVP;
using SkinData;
using UnityEngine;

namespace Views
{
    public class MainViewModel : IModel<MainViewData>
    {
        public Action<MainViewData> OnDataChanged { get; set; }

        private const string FileName = "SkinData";

        private List<SkinCollectionSO> _skinDataCollections;
        private MainViewData _data;

        public void Initialize()
        {
            _data = new MainViewData(
                new List<SkinCollectionSO>(Resources.LoadAll<SkinCollectionSO>("SkinData/Collections").ToList()));
        }

        public void UpdateData(MainViewData viewData)
        {
            _skinDataCollections = viewData.SkinDataCollections;
        }

        public MainViewData GetData()
        {
            return _data;
        }
    }
}