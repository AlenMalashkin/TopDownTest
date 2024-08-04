using System;
using Code.Services.ProgressService;
using Code.Services.SaveLoadService;

namespace Code.Services.ScoreService
{
    public class ScoreService : IScoreService
    {
        public event Action<int> ScoreChanged;
        public int RecordScore => _progressService.Progress.MaxScore;
        public int CurrentScore => _currentScore;

        private int _currentScore;
        private IProgressService _progressService;
        private ISaveLoadService _saveLoadService;

        public ScoreService(IProgressService progressService, ISaveLoadService saveLoadService)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }
        
        public void AddScore(int score)
        {
            _currentScore += score;
            ScoreChanged?.Invoke(_currentScore);
        }

        public void Reset()
            => _currentScore = 0;
        
        public void SaveNewMaxScoreIfPreviousBeaten()
        {
            if (RecordScore < CurrentScore)
            {
                _progressService.Progress.MaxScore = CurrentScore;
                _saveLoadService.SaveProgress();
            }
        }
    }
}