using System;
using System.Collections.Generic;
using System.IO;
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
            var collectionScriptableObjects = Resources.LoadAll<SkinCollectionSO>(Path.Combine("SkinData","Collections"));
            _data = SaveSystem.Load(FileName, (data) =>
                {
                    data.SetDependencies(collectionScriptableObjects);
                    return data;
                }, 
                () => new MainViewData(collectionScriptableObjects));
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