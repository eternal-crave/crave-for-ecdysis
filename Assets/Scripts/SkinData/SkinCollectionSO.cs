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
}