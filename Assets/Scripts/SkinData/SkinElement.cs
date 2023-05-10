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

        public void Initialize(SkinSO skinSO)
        {
            _skinSO = skinSO;
            _disabledImage = skinImage.sprite;
        
            SetActive(_skinSO.State);
            gameObject.SetActive(true);
        }

        public void SetActive(bool state)
        {
            _skinSO.State = state;
            button.interactable = state;
            skinImage.sprite = state ? _skinSO.Image : _disabledImage;
        }

        private void OnEnable()
        {
            button.onClick.AddListener(OnSkinSelect);
        }

        private void OnSkinSelect()
        {
            Debug.Log($"Selected Skin : {_skinSO.SkinName}");
            OnSelect?.Invoke(_skinSO);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnSkinSelect);
        }
    }
}