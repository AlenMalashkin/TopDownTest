using Code.UI.Elements;
using Code.UI.Windows;
using Code.UI.Windows.Menu;
using UnityEngine;

namespace Code.Infrastructure.Factories.UIFactory
{
    public interface IUIFactory
    { 
        MenuWindow CreateMenuWindow(WindowType type);
        ScoreViewer CreateScoreViewer(Transform root);
        RecordViewer CreateRecordViewer(Transform root);
        Transform CreateUIRoot();
    }
}