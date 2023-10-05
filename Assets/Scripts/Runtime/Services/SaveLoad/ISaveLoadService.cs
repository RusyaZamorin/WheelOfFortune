namespace WheelOfFortune.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        public void Save<T>(T value, string key);
        public bool Load<T>(string key, out T loadedValue);
    }
}