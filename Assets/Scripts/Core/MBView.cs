using System;
using Core.MVP;
using UnityEngine;

namespace Views
{
    public abstract class MBView<T> : MonoBehaviour, IView<T> where T:IData
    {
        public event Action OnClose;
        public Action<T> OnViewDataChanged { get; set; }
        public abstract void Initialize(T data);
        public abstract void UpdateView(T data);
        
        protected virtual void Close()
        {
            OnClose?.Invoke();
            OnClose = null;
            gameObject.SetActive(false);
        }
        
        protected virtual void Activate()
        {
            gameObject.SetActive(true);
        }
    }
}