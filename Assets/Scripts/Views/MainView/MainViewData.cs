using System.Collections.Generic;
using Core.MVP;
using SkinData;

namespace Views
{
    public class MainViewData : IData
    {
        public List<SkinCollection> SkinDataCollections;
        public MainViewData(List<SkinCollection> data)
        {
            SkinDataCollections = new List<SkinCollection>(data);
        }
    }
}