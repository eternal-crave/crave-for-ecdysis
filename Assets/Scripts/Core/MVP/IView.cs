using System;

namespace Core.MVP
{
    public interface IView<T> where T: IData
    {
        public Action<T> OnViewDataChanged { get; set; }
        public void Initialize(T data);
    }
}