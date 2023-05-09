using System;

namespace Core.MVP
{
    public interface IView<T> where T: IData
    {
        public void Initialize(T data);
        public void UpdateView(T data);
        public Action<T> OnViewDataChanged { get; set; }
    }
}