using UnityEngine;
using UnityEngine.UI;

namespace SkinData
{
    public class Skin : MonoBehaviour
    {
        [SerializeField] private Image skinImage;
    
        private int _id;
        private string _skinName;
        private bool _state;
        private Sprite _activatedImage;
        private Sprite _disabledImage;
    
        public void Initialize(SkinSO skinSO)
        {
            _id = skinSO.ID;
            _skinName = skinSO.SkinName;
            _state = skinSO.State;
            _activatedImage = skinSO.Image;
            _disabledImage = skinImage.sprite;
        
            SetActive(_state);
            gameObject.SetActive(true);
        }

        private void SetActive(bool state)
        {
            _state = state;
            skinImage.sprite = _state ? _activatedImage : _disabledImage;
        }
    
    }
}