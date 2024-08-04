using System;
using Code.Services.ScoreService;
using Code.Services.StaticDataService;
using TMPro;
using UnityEngine;

namespace Code.UI.Elements
{
    public class ScoreViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private IScoreService _scoreService;

        public void Init(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        private void Start()
        {
            SetScoreText(_scoreService.CurrentScore);
            _scoreService.ScoreChanged += SetScoreText;
        }

        private void OnDisable()
        {
            _scoreService.ScoreChanged -= SetScoreText;
        }

        private void SetScoreText(int score)
            => _scoreText.text = "Score: " + score;
    }
}