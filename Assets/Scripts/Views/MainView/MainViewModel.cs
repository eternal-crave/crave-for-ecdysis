using System;
using System.Collections.Generic;
using System.Linq;
using Core.MVP;
using UnityEngine;

namespace Views
{
    public class MainViewModel: IModel<MainViewData>
    {
        private List<SkinData> _skinDatas;
        public Action<MainViewData> OnDataChanged { get; set; }
        public void Initialize()
        {
            _skinDatas = Resources.LoadAll<SkinData>("SkinData").ToList();
        }

        public void UpdateData(MainViewData viewData)
        {
            _skinDatas = viewData.SkinsData;
        }

        public MainViewData GetData()
        {
            return new MainViewData(new List<SkinData>(_skinDatas));
        }
    }
}