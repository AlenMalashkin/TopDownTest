using System;
using System.Collections;
using Code.Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Services.SceneLoadService
{
    public class SceneLoadService : ISceneLoadService
    {
        private ICoroutineRunner _coroutineRunner;

        public SceneLoadService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadScene(string sceneName, Action action = null)
            => _coroutineRunner.StartCoroutine(LoadSceneRoutine(sceneName, action));
        
        private IEnumerator LoadSceneRoutine(string sceneName, Action action)
        {
            AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);

            while (!scene.isDone)
                yield return null;
            
            action?.Invoke();
        }
    }
}