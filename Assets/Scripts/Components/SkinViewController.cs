using System;
using System.Collections.Generic;
using SkinData;
using UnityEngine;
using UnityEngine.UI;
using Views;
using Random = UnityEngine.Random;

namespace Components
{
    public class SkinViewController : MonoBehaviour
    {
        public event Action<Skin> OnSkinSelect;

        [SerializeField] private SkinElement element;
        [SerializeField] private RectTransform container;
        [SerializeField] private CatalogController catalogController;
        [SerializeField] private Button unlockRandomSkinButton;

        private Dictionary<int, List<SkinElement>> _lockedElements = new();


        private void OnEnable()
        {
            unlockRandomSkinButton.onClick.AddListener(UnlockRandomSkin);
            catalogController.OnPageChange += ButtonValidation;
        }

        private void OnDisable()
        {
            unlockRandomSkinButton.onClick.RemoveListener(UnlockRandomSkin);
            catalogController.OnPageChange -= ButtonValidation;
        }

        public void PopulateElements(List<SkinCollection> collections)
        {
            LinkedList<RectTransform> pagesLinkedList = new LinkedList<RectTransform>();
            foreach (var collection in collections)
            {
                //TODO implement factory?
                RectTransform parent = Instantiate(container, container.parent);
                pagesLinkedList.AddLast(parent);
                _lockedElements[parent.GetInstanceID()] = new List<SkinElement>();
                foreach (var sd in collection.Skins)
                {
                    SkinElement e = Instantiate(element, parent);
                    if(!sd.State) _lockedElements[parent.GetInstanceID()].Add(e);

                    e.OnSelect += OnElementSelect;
                    e.Initialize(sd);
                }
            }

            catalogController.Initialize(pagesLinkedList);
        }

        private void UnlockRandomSkin()
        {
            if (_lockedElements[catalogController.ActivePageID].Count == 0) return;
            int index = Random.Range(0, _lockedElements[catalogController.ActivePageID].Count);
            SkinElement skinElement = _lockedElements[catalogController.ActivePageID][index];
            skinElement.SetState(true);
            _lockedElements[catalogController.ActivePageID].RemoveAt(index);
            ButtonValidation();
        }

        private void ButtonValidation()
        {
            unlockRandomSkinButton.gameObject.SetActive(_lockedElements[catalogController.ActivePageID].Count != 0);
        }

        private void OnElementSelect(Skin obj)
        {
            OnSkinSelect?.Invoke(obj);
        }
    }
}