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
        
        private const string FileName = "SkinData";
        
        private List<SkinCollection> _skinDataCollections;
        private MainViewData _data;
        
        public void Initialize()
        {
            _data = SaveSystem.Load(FileName, () =>
            {
                _skinDataCollections = Resources.LoadAll<SkinCollection>("SkinData/Collections").ToList();
                return new MainViewData(new List<SkinCollection>(_skinDataCollections));
            });
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