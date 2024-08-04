using UnityEngine;

namespace Code.GameLogic.PlayerLogic
{
    public class PlayerEffects : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private float _effectDuration = 10f;
        
        public bool Immortal => _immortal;
        private bool _immortal;

        private Timer _immortalityEffectTimer = new Timer();
        private Timer _speedEffectTimer = new Timer();
        
        private void Update()
        {
            _immortalityEffectTimer?.Tick();
            _speedEffectTimer?.Tick();
        }

        public void ApplyImmortality()
        {
            _immortalityEffectTimer.StartTimer(_effectDuration, RemoveImmortality);
            _immortal = true;
        }
        
        public void RemoveImmortality()
            => _immortal = false;

        public void ApplySpeedEffect(float speedMultiplier)
        {
            _speedEffectTimer.StartTimer(_effectDuration, RemoveSpeedEffect);
            _playerMovement.AddSpeedMultiplier(speedMultiplier);
        }

        public void RemoveSpeedEffect()
        {
            _playerMovement.AddSpeedMultiplier(1f);
        }
    }
}