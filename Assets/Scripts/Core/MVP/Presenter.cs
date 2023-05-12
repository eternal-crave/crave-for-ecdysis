namespace Core.MVP
{
    public abstract class Presenter<TModel, TView, TData> 
        where TModel : IModel<TData>
        where TView : IView<TData>
        where TData : IData
    {
        protected readonly TModel Model;
        protected readonly TView View;

        protected Presenter(TModel model, TView view)
        {
            Model = model;
            View = view;

            model.OnDataChanged += View.UpdateView;
            view.OnViewClose += model.SaveData;
        }
    }
}