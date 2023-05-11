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
        public bool State;
        [field:SerializeField] public Sprite Image { get; private set; }
        public int ID => GetInstanceID();
    }
    
    // Using wrapper in order to correctly serialize nested scriptable objects data
    // It is not good solution, instead it would be great to use NewtonJson, but for now use of 3rd party plugins is forbidden c,:
    [Serializable]
    public class SkinDataWrapper
    {
        public bool State;
    }
}