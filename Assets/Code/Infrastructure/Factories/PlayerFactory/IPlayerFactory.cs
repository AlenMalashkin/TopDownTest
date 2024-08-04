using Code.GameLogic.PlayerLogic;
using UnityEngine;

namespace Code.Infrastructure.Factories.PlayerFactory
{
    public interface IPlayerFactory
    {
        Player CreatePlayer(Vector3 position);
        PlayerCamera CreateFollowingCamera(Transform followTarget);
    }
}