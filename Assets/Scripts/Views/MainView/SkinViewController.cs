using System.Collections.Generic;
using SkinData;
using UnityEngine;

namespace Views
{
    public class SkinViewController : MonoBehaviour
    {
        [SerializeField] private SkinElement element;
        private List<SkinElement> _skinsList = new();

        public void PopulateElements(List<SkinSO> list)
        {
            //TODO implement factory
            list.ForEach(sd =>
            {
                SkinElement e = Instantiate(element, transform);
                _skinsList.Add(e);
                
                e.Initialize(sd);
            });
        }
    }
}
