using System;
using UnityEditor;
using UnityEngine;

namespace SkinData
{
    [CreateAssetMenu(fileName = "NewSkinData", menuName = "Data/SkinData")]
    [Serializable]
    public class SkinSO : ScriptableObject
    {
        public string SkinName => name;

        public bool State
        {
            get => PlayerPrefs.GetInt(SkinName, 0) == 1;
            set => PlayerPrefs.SetInt(SkinName, value ? 1 : 0);
        }
        [field:SerializeField] public Sprite Image { get; private set; }
    }
}