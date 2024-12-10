using UnityEngine;

namespace Game.Scripts.Environment
{
    public class BackGroundTiledController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] spriteRenderers;
        [SerializeField] private float parallaxFactor = 0.5f;
        [SerializeField] private float widthBg = 50;

        private Camera _camera;
        private Vector3 _previousCameraPosition;

        private void Awake()
        {
            _camera = Camera.main;
            _previousCameraPosition = _camera.transform.position;
        }

        private void LateUpdate()
        {
            if (_previousCameraPosition != _camera.transform.position)
            {
                Vector3 cameraDelta = _camera.transform.position - _previousCameraPosition;

                foreach (var spriteRenderer in spriteRenderers)
                {
                    Vector3 newPosition = spriteRenderer.transform.position;
                    newPosition.x += cameraDelta.x * parallaxFactor;
                    spriteRenderer.transform.position = newPosition;
                    spriteRenderer.size =
                        new Vector2(widthBg + _camera.transform.position.x, spriteRenderer.size.y);
                }

                _previousCameraPosition = _camera.transform.position;
            }
        }
    }
}