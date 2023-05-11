using System;
using System.Collections.Generic;
using Core.MVP;
using SkinData;

namespace Views
{
    [Serializable]
    public class MainViewData : IData
    {
        public List<SkinCollectionSO> SkinDataCollections;
        public MainViewData(List<SkinCollectionSO> data)
        {
            SkinDataCollections = new List<SkinCollectionSO>(data);
        }

        public void SetData(MainViewDataWrapper dataWrapper)
        {
            for (var i = 0; i < dataWrapper.SkinDataCollections.Count; i++)
            {
                for (var j = 0; j < dataWrapper.SkinDataCollections[i].SkinDataWrapper.Count; j++)
                {
                    SkinDataCollections[i].Skins[j].State = dataWrapper.SkinDataCollections[i].SkinDataWrapper[j].State;
                }
            }
        }
    }
    
    // Using wrapper in order to correctly serialize nested scriptable objects data
    // It is not good solution, instead it would be great to use NewtonJson, but for now use of 3rd party plugins is forbidden c,:
    [Serializable]
    public class MainViewDataWrapper
    {
        public List<SkinCollectionDataWrapper> SkinDataCollections;

        public MainViewDataWrapper(MainViewData mainViewData)
        {
            SkinDataCollections = new List<SkinCollectionDataWrapper>(mainViewData.SkinDataCollections.Count);
            foreach (var collectionSO in mainViewData.SkinDataCollections)
            {
                SkinDataCollections.Add(new SkinCollectionDataWrapper(collectionSO.Skins));
            }
        }
    }
}