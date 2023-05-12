using System;
using UnityEditor;
using UnityEngine;
using Views;

namespace SkinData
{
    [CreateAssetMenu(fileName = "NewSkinData", menuName = "Data/SkinData")]
    [Serializable]
    public class SkinSO : ScriptableObject
    {
        private string _skinName;
        public string SkinName => _skinName;
       public bool defaultState;

        public bool State
        {
            get => SaveSystem.GetState(SkinName, defaultState);
            set => SaveSystem.SetState(SkinName, value);
        }
        [field:SerializeField] public Sprite Image { get; private set; }

        public void Initialize(string parentName)
        {
            _skinName = $"{parentName}_{name}";
        }
    }
}