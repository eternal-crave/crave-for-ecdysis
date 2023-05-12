using System;
using System.Collections.Generic;

namespace SkinData
{
    [Serializable]
    public class SkinCollection
    {
        public List<Skin> Skins;
        public SkinCollection(SkinCollectionSO skinCollectionSO)
        {
            Skins = new List<Skin>();
            foreach (var skinSO in skinCollectionSO.SkinSOList)
            {
                Skins.Add(new Skin(skinSO,skinCollectionSO.name));
            }
        }
    }
}