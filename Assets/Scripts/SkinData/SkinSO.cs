using System;
using UnityEditor;
using UnityEngine;

namespace SkinData
{
    [CreateAssetMenu(fileName = "NewSkinData", menuName = "Data/SkinData")]
    public class SkinSO : ScriptableObject
    {
#if  UNITY_EDITOR
        private bool _initialState;
        private void OnEnable()
        {
            _initialState = State;
        }

        private void OnDisable()
        {
            State = _initialState;
        }
#endif
        
        public string SkinName => name;
        public bool State;
        [field:SerializeField] public Sprite Image { get; private set; }
        public int ID => GetInstanceID();
    }
}