using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace WheelOfFortune.Services.SaveLoad
{
    public class PlayerPrefsSaveLoadService : ISaveLoadService
    {
        public void Save<T>(T value, string key)
        {
            var jsonValue = JsonConvert.SerializeObject(value);
            PlayerPrefs.SetString(key, jsonValue);
        }

        public bool Load<T>(string key, out T loadedValue)
        {
            if (PlayerPrefs.HasKey(key))
            {
                var jsonValue = PlayerPrefs.GetString(key);
                loadedValue = JsonConvert.DeserializeObject<T>(jsonValue);
                return true;
            }

            loadedValue = default;
            return false;
        }
        
    }
}