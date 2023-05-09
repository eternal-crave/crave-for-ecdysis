using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class SkinViewController : MonoBehaviour
    {
        [SerializeField] private Skin element;

        public void PopulateElements(List<SkinData> list)
        {
            //TODO implement factory
            list.ForEach(sd => Instantiate(element, transform).Initialize(sd));
        }
    }
}
