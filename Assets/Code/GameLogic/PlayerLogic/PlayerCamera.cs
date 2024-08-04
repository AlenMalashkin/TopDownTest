using UnityEngine;

namespace Code.GameLogic.PlayerLogic
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Vector3 _viewLimit;

        private Transform _followTarget;

        public void Follow(Transform followTarget)
            => _followTarget = followTarget;

        private void Update()
        {
            transform.position = new Vector3(Mathf.Clamp(_followTarget.position.x + _offset.x, -_viewLimit.x, _viewLimit.x),
                _offset.y, Mathf.Clamp(_followTarget.position.z + _offset.z, -_viewLimit.z, _viewLimit.z));
        }
    }
}