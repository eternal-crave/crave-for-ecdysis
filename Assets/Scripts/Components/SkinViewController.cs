using System;
using System.Collections.Generic;
using System.Linq;
using SkinData;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Components
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

        public void UnlockRandomSkin()
        {
           List<SkinElement> lockedElements = _skinsList.Where(e => !e.SkinDataSO.State).ToList();
           if(lockedElements.Count == 0) return;
           SkinElement skinElement = lockedElements[Random.Range(0, lockedElements.Count)];
           skinElement.SetActive(true);
           OnSkinStateChanged?.Invoke(skinElement.SkinDataSO);
        }
    }
}
