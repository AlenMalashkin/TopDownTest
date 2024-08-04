using System;

namespace Code.Services.ScoreService
{
    public interface IScoreService
    {
        event Action<int> ScoreChanged;
        int RecordScore { get; }
        int CurrentScore { get; }
        void AddScore(int score);
        void Reset();
        void SaveNewMaxScoreIfPreviousBeaten();
    }
}