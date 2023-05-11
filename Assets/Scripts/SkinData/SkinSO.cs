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
        public string SkinName => name;

        public bool State
        {
            get => SaveSystem.GetState(SkinName);
            set => SaveSystem.SetState(SkinName, value);
        }
        [field:SerializeField] public Sprite Image { get; private set; }
    }
}