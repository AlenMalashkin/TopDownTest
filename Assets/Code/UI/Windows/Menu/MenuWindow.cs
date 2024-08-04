using Code.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows.Menu
{
    public class MenuWindow : WindowBase
    {
        [SerializeField] private Button _playButton;

        private Game _game;
        
        public void Init(Game game)
        {
            _game = game;
            
            _playButton.onClick.AddListener(OnPlayClick);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayClick);
        }

        private void OnPlayClick()
        {
            _game.StartGame();
        }
    }
}