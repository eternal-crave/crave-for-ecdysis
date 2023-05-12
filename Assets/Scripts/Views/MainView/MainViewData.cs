using System;
using System.Collections.Generic;
using Core.MVP;
using SkinData;

namespace Views
{
    [Serializable]
    public class MainViewData : IData
    {
        public List<SkinCollection> SkinDataCollections;

        public MainViewData()
        {
            
        }
        public MainViewData(SkinCollectionSO[] data)
        {
            SkinDataCollections = new List<SkinCollection>();
            foreach (SkinCollectionSO collectionSO in data)
            {
                SkinDataCollections.Add(new SkinCollection(collectionSO));
            }
        }

        public void SetDependencies(SkinCollectionSO[] collectionScriptableObjects)
        {
            for (int i = 0; i < SkinDataCollections.Count; i++)
            {
                SkinDataCollections[i].SetDependencies(collectionScriptableObjects[i]);
            }
        }
    }
}