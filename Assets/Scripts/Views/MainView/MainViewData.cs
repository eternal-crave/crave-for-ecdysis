using System.Collections.Generic;
using Core.MVP;

namespace Views
{
    public class MainViewData : IData
    {
        public List<SkinData> SkinsData;

        public MainViewData()
        {
            
        }
        public MainViewData(List<SkinData> data)
        {
            SkinsData = new List<SkinData>(data);
        }
    }
}