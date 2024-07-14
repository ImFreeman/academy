using Features.Core.Movement.Scripts.Interfaces;
using UnityEngine;

namespace Features.Core.Movement.Scripts.Realization
{
    public class CharacterControllerMovementComponent : MonoBehaviour, IMovementComponent
    {
        [SerializeField] private Transform _bodyTransform;
        [SerializeField] private CharacterController _characterController;

        public Transform BodyTransform => _bodyTransform;

        public void Move(Vector3 value)
        {
            _characterController.Move(value);
        }
    }
}