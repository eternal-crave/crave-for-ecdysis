using System;

namespace Core.MVP
{
    public interface IView<T> where T: IData
    {
        public Action<T> OnViewClose { get; set; }
        public void Initialize(T data);
        public void UpdateView(T data);
    }
}