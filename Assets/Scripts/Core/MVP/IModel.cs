using System;

namespace Core.MVP
{
    public interface IModel<T> where T:IData
    {
        public Action<T> OnDataChanged { get; set; }
        public void Initialize();
        public void SaveData(T data);
        public T GetData();
    }
}