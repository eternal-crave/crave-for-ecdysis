using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace SkinData
{
    public class SkinElement : MonoBehaviour
    {
        public event Action<Skin> OnSelect;
        
        [SerializeField] private Image skinImage;
        [SerializeField] private Button button;

        public Skin SkinDataSO => _skin;
    
        private Sprite _disabledImage;
        private Skin _skin;

        public void Initialize(Skin skin)
        {
            _skin = skin;
            _disabledImage = skinImage.sprite;
        
            SetState(_skin.State);
            if (_skin.IsSelected)
            {
                Select();
            }
            gameObject.SetActive(true);
        }

        public void SetState(bool state)
        {
            _skin.State = state;
            button.interactable = state;
            skinImage.sprite = state ? _skin.Image : _disabledImage;
        }

        private void OnEnable()
        {
            button.onClick.AddListener(Select);
        }

        public void Select()
        {
            OnSelect?.Invoke(_skin);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(Select);
        }
    }
}