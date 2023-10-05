using System;
using Newtonsoft.Json;
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
            loadedValue = default;

            if (PlayerPrefs.HasKey(key))
            {
                var jsonValue = PlayerPrefs.GetString(key);
                try
                {
                    loadedValue = JsonConvert.DeserializeObject<T>(jsonValue);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                
                return true;
            }

            return false;
        }
        
    }
}