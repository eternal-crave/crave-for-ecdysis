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
            MainViewDataWrapper dataWrapper = SaveSystem.Load<MainViewDataWrapper>(FileName, () =>
            {
                Debug.Log("No data to load. Using defaults");
                return null;
            });

            //Setting saved values
            if (dataWrapper != null)
            {
                _data.SetData(dataWrapper);
            }

            foreach (var skinSo in _data.SkinDataCollections[0].Skins)
            {
                Debug.Log($"Name:{skinSo.SkinName} ---- state: {skinSo.State}");
            }
        }

        public void UpdateData(MainViewData viewData)
        {
            _skinDataCollections = viewData.SkinDataCollections;
        }

        public MainViewData GetData()
        {
            return _data;
        }

        public void SaveData()
        {
            SaveSystem.Save(FileName, new MainViewDataWrapper(_data));
            foreach (var skinSo in _data.SkinDataCollections[0].Skins)
            {
                Debug.Log($"Name:{skinSo.SkinName} ---- state: {skinSo.State}");
            }
        }
    }
}