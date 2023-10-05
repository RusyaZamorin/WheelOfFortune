using WheelOfFortune.Services.SaveLoad;
using Zenject;

namespace WheelOfFortune.Services
{
    public class PlayerScoreService : IInitializable
    {
        private const string ScoreSaveKey = "PlayerScore";

        private ISaveLoadService saveLoadService;
        private int playerScore;
        
        public int PlayerScore
        {
            get => playerScore;
            private set
            {
                playerScore = value;
                SaveScore();
            }
        }

        [Inject]
        public PlayerScoreService(ISaveLoadService saveLoadService) => 
            this.saveLoadService = saveLoadService;

        public void IncreaseScore(int value) =>
            PlayerScore += value;

        public void Initialize() => 
            LoadScore();

        private void SaveScore() => 
            saveLoadService.Save(playerScore, ScoreSaveKey);

        private void LoadScore()
        {
            if (saveLoadService.Load(ScoreSaveKey, out int loadedValue))
                playerScore = loadedValue;
        }
    }
}