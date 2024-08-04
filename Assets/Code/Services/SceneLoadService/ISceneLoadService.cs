using System;

namespace Code.Services.SceneLoadService
{
    public interface ISceneLoadService
    {
        void LoadScene(string sceneName, Action action = null);
    }
}