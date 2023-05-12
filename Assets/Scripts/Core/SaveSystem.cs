using System;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

namespace Views
{
    public static class SaveSystem
    {
        public static void Save<T>(string fileName, T data)
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Path.Combine(Application.persistentDataPath,$"{fileName}.json"), json);
            Debug.Log($"DATA :{data}");
            Debug.Log($"Data saved :{json}");
        }

        public static T Load<T>(string fileName, Func<T> newObjectCreation = null) where T:class
        {
            if (!File.Exists(Path.Combine(Application.persistentDataPath,$"{fileName}.json")))
                return newObjectCreation?.Invoke();
            string json = File.ReadAllText(Path.Combine(Application.persistentDataPath,$"{fileName}.json"));
            Debug.Log($"Data loaded");
            return JsonUtility.FromJson<T>(json);
            
        }
    }
}