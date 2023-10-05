using UnityEngine;

namespace WheelOfFortune.Services.SaveLoad
{
    public class PlayerPrefsSaveLoadService : ISaveLoadService
    {
        public void Save<T>(T value, string key)
        {
            var jsonValue = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(key, jsonValue);
        }

        public bool Load<T>(string key, out T loadedValue)
        {
            if (PlayerPrefs.HasKey(key))
            {
                var jsonValue = PlayerPrefs.GetString(key);
                loadedValue = JsonUtility.FromJson<T>(jsonValue);
                return true;
            }

            loadedValue = default;
            return false;
        }
        
    }
}