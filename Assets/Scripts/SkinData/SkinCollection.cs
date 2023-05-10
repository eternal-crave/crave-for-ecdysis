using System.Collections.Generic;
using UnityEngine;

namespace SkinData
{
    [CreateAssetMenu(fileName = "NewSkinCollection", menuName = "Data/SkinDataCollection")]
    public class SkinCollection : ScriptableObject
    {
        public List<SkinSO> Skins;
    }
}