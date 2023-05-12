using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace SkinData
{
    [Serializable]
    public class SkinCollection
    {
        [JsonProperty("_skins")] private List<Skin> _skins;
        public ReadOnlyCollection<Skin> Skins => _skins.AsReadOnly();

        public SkinCollection()
        {
            
        }
        public SkinCollection(SkinCollectionSO skinCollectionSO)
        {
            _skins = new List<Skin>();
            foreach (var skinSO in skinCollectionSO.SkinSOList)
            {
                _skins.Add(new Skin(skinSO,skinCollectionSO.name));
            }
        }

        public void SetDependencies(SkinCollectionSO collection)
        {
            for (int i = 0; i < _skins.Count; i++)
            {
                _skins[i].SetDependencies(collection.SkinSOList[i], collection.name);
            }
        }
    }
}