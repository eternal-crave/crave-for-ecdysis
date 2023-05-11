using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SkinData
{
    [CreateAssetMenu(fileName = "NewSkinCollection", menuName = "Data/SkinDataCollection")]
    [Serializable]
    public class SkinCollectionSO : ScriptableObject
    {
        public List<SkinSO> Skins;
    }
    
    
    // Using wrapper in order to correctly serialize nested scriptable objects data
    // It is not good solution, instead it would be great to use NewtonJson, but for now use of 3rd party plugins is forbidden c,:
    [Serializable]
    public class SkinCollectionDataWrapper
    {
        public List<SkinDataWrapper> SkinDataWrapper;

        public SkinCollectionDataWrapper(List<SkinSO> skins)
        {
            SkinDataWrapper = new List<SkinDataWrapper>();
            foreach (var skinSO in skins)
            {
                SkinDataWrapper skinDataWrapper = new SkinDataWrapper() { State = skinSO.State };
                SkinDataWrapper.Add(skinDataWrapper);
            }
        }
    }
}