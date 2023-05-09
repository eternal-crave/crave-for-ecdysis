using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] private Image skinImage;
    
    private int _id;
    private string _skinName;
    private bool _state;
    private Sprite _activatedImage;
    private Sprite _disabledImage;
    
    public void Initialize(SkinData skinData)
    {
        _id = skinData.ID;
        _skinName = skinData.SkinName;
        _state = skinData.State;
        _activatedImage = skinData.ActivatedImage;
        _disabledImage = skinData.DisabledImage;
        
        SetActive(_state);
        gameObject.SetActive(true);
    }

    private void SetActive(bool state)
    {
        _state = state;
        skinImage.sprite = _state ? _activatedImage : _disabledImage;
    }
    
}