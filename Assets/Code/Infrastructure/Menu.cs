using Code.Infrastructure.Factories.UIFactory;
using Code.Services.SceneLoadService;
using Code.Services.StaticDataService;
using Code.UI.Windows;

namespace Code.Infrastructure
{
    public class Menu
    {
        private IUIFactory _iuiFactory;
        private ISceneLoadService _sceneLoadService;
        private Game _game;
        
        public Menu(IUIFactory iuiFactory, ISceneLoadService sceneLoadService, Game game)
        {
            _iuiFactory = iuiFactory;
            _sceneLoadService = sceneLoadService;
            _game = game;
        }
        
        public void OpenMenu()
        {
            _sceneLoadService.LoadScene("Menu", OnLoad);
        }

        private void OnLoad()
        {
            _iuiFactory.CreateMenuWindow(WindowType.Menu)
                .Init(_game);
        }
    }
}