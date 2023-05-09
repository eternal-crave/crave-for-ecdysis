namespace Core.MVP
{
    public abstract class Presenter<TModel, TView> 
        where TModel : IModel<IData> 
        where TView : IView<IData> 
    {
        protected readonly TModel Model;
        protected readonly TView View;

        protected Presenter(TModel model, TView view)
        {
            Model = model;
            View = view;
            
            model.OnDataChanged += View.UpdateView;
            view.OnViewDataChanged += model.UpdateData;
            
            Model.Initialize();
            View.Initialize(Model.GetData());

            
        }
    }
}