using System;
using Unity.VisualScripting;
using UnityEngine;

namespace SkinData
{
    [Serializable]
    public class SkinState
    {
        [SerializeField] private int _id;
        [SerializeField] private bool _state;

        public int ID => _id;
        public bool State => _state;

        public SkinState(int id, bool state)
        {
            _id = id;
            _state = state;
        }
        public void ChangeState(bool state)
        {
            _state = state;
        }
    }
}