using UnityEngine;

namespace Views
{
    public static class SaveSystem
    {
        public static bool GetState(string name, bool defaultValue)
        {
            if (!PlayerPrefs.HasKey(name)) return defaultValue;
            return PlayerPrefs.GetInt(name, 0) == 1;
        }

        public static void SetState(string name, bool state) => PlayerPrefs.SetInt(name, state ? 1 : 0);
        public static string SelectedElementName
        {
            get => PlayerPrefs.GetString("LastSelection","");
            set => PlayerPrefs.SetString("LastSelection", value);
        }
    }
}