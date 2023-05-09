using UnityEngine;

[CreateAssetMenu(fileName = "NewSkinData", menuName = "Data/SkinData")]
public class SkinData : ScriptableObject
{
    public int ID;
    public string SkinName;
    public bool State;
    public Sprite ActivatedImage;
    public Sprite DisabledImage;
}