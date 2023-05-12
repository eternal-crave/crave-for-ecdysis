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

        public MainViewData(List<SkinCollectionSO> data)
        {
            SkinDataCollections = new List<SkinCollection>();
            foreach (SkinCollectionSO collectionSO in data)
            {
                SkinDataCollections.Add(new SkinCollection(collectionSO));
            }
        }
    }
}