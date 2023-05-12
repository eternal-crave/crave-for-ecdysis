using SkinData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    public class SkinOverview : MonoBehaviour
    {
        [SerializeField] private Image skinImage;
        [SerializeField] private TMP_Text skinName;

        public void SetData(Skin data)
        {
            skinImage.sprite = data.Image;
            skinName.text = data.Name;
        }
    }
}