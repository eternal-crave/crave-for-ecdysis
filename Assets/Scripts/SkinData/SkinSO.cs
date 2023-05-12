using System;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Views;

namespace SkinData
{
    [CreateAssetMenu(fileName = "NewSkinData", menuName = "Data/SkinData")]
    public class SkinSO : ScriptableObject
    {
        [SerializeField] private bool defaultState;
        [SerializeField] private Sprite image;
        public bool DefaultState => defaultState;
        public Sprite Image => image;
    }
}