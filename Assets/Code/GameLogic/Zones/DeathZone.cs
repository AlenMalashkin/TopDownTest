using Code.GameLogic.PlayerLogic;
using UnityEngine;

namespace Code.GameLogic.Zones
{
    public class DeathZone : Zone
    {
        public override void ApplyZoneEffect(Collider other)
        {
            if (other.TryGetComponent(out PlayerDeath playerDeath))
                playerDeath.Die();
        }

        public override void ExitZone(Collider other)
        {
        }
    }
}