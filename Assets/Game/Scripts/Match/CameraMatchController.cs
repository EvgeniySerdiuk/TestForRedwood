using System;
using UnityEngine;

namespace Game.Scripts.Match
{
    public class CameraMatchController : MonoBehaviour
    {
        [SerializeField] private float offset = 2f;
        [SerializeField] private float cameraSpeed = 0.3f;

        private Transform _target;
        private Vector3 _velocity = Vector3.zero;

        private void LateUpdate()
        {
            if (_target)
            {
                Vector3 targetPosition =
                    new Vector3(_target.position.x + offset, transform.position.y, transform.position.z);

                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, cameraSpeed);
            }
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}