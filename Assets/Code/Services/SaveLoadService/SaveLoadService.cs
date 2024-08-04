using Code.Data;
using Code.Services.ProgressService;
using UnityEngine;

namespace Code.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private IProgressService _progressService;

        public SaveLoadService(IProgressService progressService)
        {
            _progressService = progressService;
        }

        public void SaveProgress()
            => PlayerPrefs.SetString("Progress", JsonUtility.ToJson(_progressService.Progress));

        public Progress LoadProgress()
            => JsonUtility.FromJson<Progress>(PlayerPrefs.GetString("Progress"));
    }
}