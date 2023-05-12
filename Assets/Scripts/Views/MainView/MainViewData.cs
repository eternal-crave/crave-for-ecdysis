using System;
using System.Collections.Generic;
using Core.MVP;
using SkinData;

namespace Views
{
    [Serializable]
    public class MainViewData : IData
    {
        public List<SkinCollectionSO> SkinDataCollections { get;}

        public MainViewData(List<SkinCollectionSO> data)
        {
            SkinDataCollections = new List<SkinCollectionSO>(data);
            SkinDataCollections.ForEach(col => col.Skins.ForEach(s => s.Initialize(col.name)));
        }
    }
}