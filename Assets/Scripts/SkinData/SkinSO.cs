using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewSkinData", menuName = "Data/SkinData")]
public class SkinSO : ScriptableObject
{
    [field:SerializeField] public string SkinName{ get; set; }
    [field:SerializeField] public bool State{ get; set; }
    [field:SerializeField] public Sprite Image{ get; set; }
    public int ID => GetInstanceID();
}