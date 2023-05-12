using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;

namespace SkinData
{
    [CreateAssetMenu(fileName = "NewSkinCollection", menuName = "Data/SkinDataCollection")]
    public class SkinCollectionSO : ScriptableObject
    {
        [JsonProperty("skinSOList")] [SerializeField] private List<SkinSO> skinSOList;
        public ReadOnlyCollection<SkinSO> SkinSOList=> skinSOList.AsReadOnly();
    }
}