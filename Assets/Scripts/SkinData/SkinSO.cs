using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Views;

namespace SkinData
{
    [CreateAssetMenu(fileName = "NewSkinData", menuName = "Data/SkinData")]
    [Serializable]
    public class SkinSO : ScriptableObject
    {
        public bool DefaultState;
        [field: SerializeField] public Sprite Image { get; private set; }
    }
}