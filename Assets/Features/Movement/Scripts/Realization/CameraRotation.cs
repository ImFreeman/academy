using Features.Core.Movement.Scripts.Interfaces;
using UnityEngine;

namespace Features.Core.Movement.Scripts.Realization
{
    public class CameraRotation : ICameraRotation
    {
        private readonly Transform _objectToRotate;
        private readonly Transform _cameraToRotate;

        public CameraRotation(
            Transform objectToRotate,
            Transform cameraToRotate
            )
        {
            _objectToRotate = objectToRotate;
            _cameraToRotate = cameraToRotate;
        }

        public void Rotate(Vector2 value)
        {
            Debug.Log($"Mouse Input {value}");
            _objectToRotate.Rotate(0, value.x * Time.deltaTime * 30.0f, 0);
            _cameraToRotate.Rotate(-value.y * Time.deltaTime * 30.0f, 0, 0);
        }
    }
}