using UnityEngine;

namespace Views
{
    public class MainView: MBView<MainViewData>
    {
        [SerializeField] private SkinViewController skinViewController;

        public override void Initialize(MainViewData data)
        {
            //TODO change to work with multiple skin data collections
            skinViewController.PopulateElements(data.SkinDataCollections[0].Skins);
        }

        public override void UpdateView(MainViewData data)
        {
            throw new System.NotImplementedException();
        }
    }
}