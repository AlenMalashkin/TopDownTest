using Code.Data;
using Code.Services.ScoreService;
using Code.Services.StaticDataService;
using Code.UI.Elements;
using Code.UI.Windows;
using Code.UI.Windows.Menu;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Infrastructure.Factories.UIFactory
{
    public class UIFactory : IUIFactory
    {
        private IStaticDataService _staticDataService;
        private IScoreService _scoreService;

        public UIFactory(IStaticDataService staticDataService, IScoreService scoreService)
        {
            _staticDataService = staticDataService;
            _scoreService = scoreService;
        }

        public MenuWindow CreateMenuWindow(WindowType type)
        {
            WindowData windowData = _staticDataService.ForWindow(type);
            MenuWindow menuWindow = Object.Instantiate(windowData.Prefab) as MenuWindow;
            CreateRecordViewer(menuWindow.transform);
            return menuWindow;
        }

        public ScoreViewer CreateScoreViewer(Transform root)
        {
            ScoreViewer prefab = Resources.Load<ScoreViewer>("Prefabs/UI/ScoreViewer"); 
            ScoreViewer scoreViewer = Object.Instantiate(prefab, root);
            scoreViewer.Init(_scoreService);
            return scoreViewer;
        }

        public RecordViewer CreateRecordViewer(Transform root)
        {
            RecordViewer prefab = Resources.Load<RecordViewer>("Prefabs/UI/RecordViewer"); 
            RecordViewer recordViewer = Object.Instantiate(prefab, root);
            recordViewer.Init(_scoreService);
            return recordViewer;
        }

        public Transform CreateUIRoot()
        {
            Transform prefab = Resources.Load<Transform>("Prefabs/UI/UIRoot"); 
            Transform uiRoot = Object.Instantiate(prefab);
            return uiRoot;
        }
    }
}