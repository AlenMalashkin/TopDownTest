using Code.Services.ScoreService;
using TMPro;
using UnityEngine;

namespace Code.UI.Elements
{
    public class RecordViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private IScoreService _scoreService;

        public void Init(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        private void Start()
        {
            _scoreText.text = "Record score: " + _scoreService.RecordScore;
        }
    }
}