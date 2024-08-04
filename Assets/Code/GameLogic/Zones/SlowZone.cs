using Code.GameLogic.PlayerLogic;
using UnityEngine;

namespace Code.GameLogic.Zones
{
    public class SlowZone : Zone
    {
        [SerializeField] private float _slowMotion = 0.6f;
        
        public override void ApplyZoneEffect(Collider other)
        {
            if (other.TryGetComponent(out PlayerMovement playerMovement))
                playerMovement.AddSpeedMultiplier(_slowMotion);
        }

        public override void ExitZone(Collider other)
        {
            if (other.TryGetComponent(out PlayerMovement playerMovement))
                playerMovement.AddSpeedMultiplier(1);
        }
    }
}