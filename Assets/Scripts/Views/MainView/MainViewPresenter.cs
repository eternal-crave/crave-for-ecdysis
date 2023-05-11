using Core.MVP;

namespace Views
{
    public class MainViewPresenter : Presenter<MainViewModel, MainView, MainViewData>
    {
        public MainViewPresenter(MainViewModel model, MainView view) : base(model, view)
        {
            view.OnClose += model.SaveData;
        }
    }
}