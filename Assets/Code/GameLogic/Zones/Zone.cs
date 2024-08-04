using UnityEngine;

namespace Code.GameLogic.Zones
{
    public abstract class Zone : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _zoneTrigger;

        private void OnEnable()
        {
            _zoneTrigger.TriggerEntered += ApplyZoneEffect;
            _zoneTrigger.TriggerExited += ExitZone;
        }

        private void OnDisable()
        {
            _zoneTrigger.TriggerEntered -= ApplyZoneEffect;
            _zoneTrigger.TriggerExited -= ExitZone;
        }

        public abstract void ApplyZoneEffect(Collider other);
        public abstract void ExitZone(Collider other);
    }
}