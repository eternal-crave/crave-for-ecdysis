using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    public class CatalogController : MonoBehaviour
    {
        public event Action OnPageChange;
        
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private Button nextPageButton;
        [SerializeField] private Button previousPageButton;
        
        private LinkedListNode<RectTransform> _activePage;
        private LinkedList<RectTransform> _pagesLinkedList = new();

        public int ActivePageID => _activePage.Value.GetInstanceID();
        private void OnEnable()
        {
            nextPageButton.onClick.AddListener(ChangeToNextPage);
            previousPageButton.onClick.AddListener(ChangeToPreviousPage);
        }

        private void OnDisable()
        {
            nextPageButton.onClick.RemoveListener(ChangeToNextPage);
            previousPageButton.onClick.RemoveListener(ChangeToPreviousPage);
        }
        
        private void ChangeToPreviousPage()
        {
            ChangePage(false);
        }

        private void ChangeToNextPage()
        {
            ChangePage(true);
        }

        /// <summary>
        /// True:Next page, 
        /// False:Previous page
        /// </summary>
        /// <param name="direction"></param>
        private void ChangePage(bool? direction)
        {
            LinkedListNode<RectTransform> newPage;
            if (direction == null) newPage = _pagesLinkedList.First;
            else
            {
                newPage = (bool)direction ? _activePage.Next : _activePage.Previous;
                if(newPage == null) return;
            }
            _activePage?.Value.gameObject.SetActive(false);
            _activePage = newPage;
            scrollRect.content = _activePage.Value;
            _activePage.Value.gameObject.SetActive(true);
            OnPageChange?.Invoke();
        }

        public void Initialize(LinkedList<RectTransform> pagesLinkedList)
        {
            _pagesLinkedList = pagesLinkedList;
            ChangePage(null);
        }
    }
}