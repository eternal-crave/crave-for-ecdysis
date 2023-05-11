using System;
using System.Collections.Generic;
using System.Linq;
using SkinData;
using UnityEngine;
using UnityEngine.UI;
using Views;
using Random = UnityEngine.Random;

namespace Components
{
    public class SkinViewController : MonoBehaviour
    {
        public event Action<SkinSO> OnSkinSelect; 
        
        [SerializeField] private SkinElement element;
        [SerializeField] private Transform container;
        [SerializeField] private Button unlockRandomSkinButton;

        private List<SkinElement> _skinsList = new();
        private string _selectedSkin;

        private void OnEnable()
        {
            unlockRandomSkinButton.onClick.AddListener(UnlockRandomSkin);
        }

        private void OnDisable()
        {
            unlockRandomSkinButton.onClick.RemoveListener(UnlockRandomSkin);
        }
        
        public void PopulateElements(List<SkinSO> list)
        {
            //TODO implement factory
            list.ForEach(sd =>
            {
                SkinElement e = Instantiate(element, container);
                _skinsList.Add(e);
                
                e.OnSelect += OnElementSelect;
                e.Initialize(sd, SaveSystem.SelectedElementName);
                
            });
        }

        public void UnlockRandomSkin()
        {
           List<SkinElement> lockedElements = _skinsList.Where(e => !e.SkinDataSO.State).ToList();
           if (lockedElements.Count == 0)
           {
               //Disabling button, if there is no more locked elements
               unlockRandomSkinButton.gameObject.SetActive(false);
               return;
           }
           SkinElement skinElement = lockedElements[Random.Range(0, lockedElements.Count)];
           skinElement.SetState(true);
        }

        private void OnElementSelect(SkinSO obj)
        {
            _selectedSkin = obj.SkinName;
            OnSkinSelect?.Invoke(obj);
        }

        private void OnApplicationQuit()
        {
            SaveSystem.SelectedElementName = _selectedSkin;
        }
    }
}
