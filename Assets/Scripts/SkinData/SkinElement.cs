using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace SkinData
{
    public class SkinElement : MonoBehaviour
    {
        public event Action<SkinSO> OnSelect;
        
        [SerializeField] private Image skinImage;
        [SerializeField] private Button button;

        public SkinSO SkinDataSO => _skinSO;
    
        private Sprite _disabledImage;
        private SkinSO _skinSO;

        public void Initialize(SkinSO skinSO, string selectedSkinName)
        {
            _skinSO = skinSO;
            _disabledImage = skinImage.sprite;
        
            SetState(_skinSO.State);
            if(_skinSO.SkinName.Equals(selectedSkinName)) Select();
            gameObject.SetActive(true);
        }

        public void SetState(bool state)
        {
            _skinSO.State = state;
            button.interactable = state;
            skinImage.sprite = state ? _skinSO.Image : _disabledImage;
        }

        private void OnEnable()
        {
            button.onClick.AddListener(Select);
        }

        public void Select()
        {
            Debug.Log($"Selected Skin : {_skinSO.SkinName}");
            OnSelect?.Invoke(_skinSO);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(Select);
        }
    }
}