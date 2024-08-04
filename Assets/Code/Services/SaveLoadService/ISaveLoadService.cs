using Code.Data;

namespace Code.Services.SaveLoadService
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        Progress LoadProgress();
    }
}