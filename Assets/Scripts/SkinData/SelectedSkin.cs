using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace SkinData
{
    [Serializable]
    public class SelectedSkin
    {
        [SerializeField] private SkinState _skinState;
        [SerializeField] private int _page;
        public int Page => _page;
        public SkinState SkinState => _skinState;

        public void SetData(int id, int page, bool state)
        {
            _skinState = new SkinState(id, state);
            _page = page;
        }
    }
}