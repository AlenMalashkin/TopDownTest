using Code.Data;

namespace Code.Services.ProgressService
{
    public interface IProgressService
    {
        Progress Progress { get; set; }
    }
}