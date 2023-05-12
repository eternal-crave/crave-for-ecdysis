using System;
using UnityEngine;

namespace SkinData
{
    [Serializable]
    public class Skin
    {
        [SerializeField] private SkinSO _skinSO;
        public Sprite Image => _skinSO.Image;
        public bool State;
        public bool IsSelected;
        public string Name { get; private set; }


        public Skin(SkinSO skinSO, string parentName)
        {
            _skinSO = skinSO;
            Name = $"{parentName}_{skinSO.name}";
            State = skinSO.DefaultState;
        }
        
    }
}