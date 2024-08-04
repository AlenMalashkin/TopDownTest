using UnityEngine;

namespace Code.GameLogic.Pickups
{
    public abstract class Pickup : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _pickupTrigger;

        private void OnEnable()
        {
            _pickupTrigger.TriggerEntered += PickupItem;
        }

        private void OnDisable()
        {
            _pickupTrigger.TriggerEntered -= PickupItem;
        }

        public abstract void PickupItem(Collider other);
    }
}