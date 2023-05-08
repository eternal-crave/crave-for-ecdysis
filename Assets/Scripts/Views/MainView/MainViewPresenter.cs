namespace Views
{
    public class MainViewPresenter
    {
        private MainView _view;
        private MainViewModel _model;

        public MainViewPresenter(MainView view, MainViewModel model)
        {
            _view = view;
            _model = model;
        }
        
        private void LoadModelData(){}
        private void UpdateModelData(){}
        private void UpdateView(){}
    }
}