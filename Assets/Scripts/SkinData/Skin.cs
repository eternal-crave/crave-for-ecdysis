using System;
using Newtonsoft.Json;
using UnityEngine;

namespace SkinData
{
    [Serializable]
    public class Skin
    {
        private SkinSO _skinSO;
        [JsonIgnore] public Sprite Image => _skinSO.Image;
        public bool State;
        public bool IsSelected;
        [JsonIgnore] public string Name { get; private set; }

        public Skin()
        {
            
        }
        public Skin(SkinSO skinSO, string parentName)
        {
            _skinSO = skinSO;
            Name = $"{parentName}_{skinSO.name}";
            State = skinSO.DefaultState;
        }

        public void SetDependencies(SkinSO skinSo, string parentName)
        {
            _skinSO = skinSo;
            Name = $"{parentName}_{skinSo.name}";
        }
    }
}