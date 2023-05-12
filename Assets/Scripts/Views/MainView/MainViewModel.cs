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

        private MainViewData _data;

        public void Initialize()
        {
            _data =
                SaveSystem.Load<MainViewData>(FileName, () => new MainViewData(
                    new List<SkinCollectionSO>(Resources.LoadAll<SkinCollectionSO>("SkinData/Collections")
                        .ToList())));
            OnDataChanged?.Invoke(_data);
        }

        public void SaveData(MainViewData viewData)
        {
            _data = viewData;
            SaveSystem.Save(FileName, _data);
        }

        public MainViewData GetData()
        {
            return _data;
        }
    }
}