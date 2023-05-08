using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Views
{
    public class MainViewModel
    {
        private List<SkinData> _skinDatas;

        public MainViewModel()
        {
            _skinDatas = Resources.LoadAll<SkinData>("SkinData").ToList();
        }
    }
}