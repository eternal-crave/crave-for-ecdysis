using System;
using UnityEngine;

namespace SkinData
{
    [CreateAssetMenu(fileName = "NewSkinData", menuName = "Data/SkinData")]
    public class SkinSO : ScriptableObject
    {
        public string SkinName => name;
        public bool State;
        public Sprite Image;
        public int ID => GetInstanceID();
    }
}