using UnityEngine;

namespace Views
{
    public class MainView: MBView<MainViewData>
    {
        [SerializeField] private SkinViewController skinViewController;

        public override void Initialize(MainViewData data)
        {
            skinViewController.PopulateElements(data.SkinsData);
        }

        public override void UpdateView(MainViewData data)
        {
            throw new System.NotImplementedException();
        }
    }
}