using Features.Core.Movement.Scripts.Interfaces;
using Features.Core.Movement.Scripts.Realization;
using Features.Enemy.Scripts.Realization;
using UnityEngine;

namespace Features.Player.Scripts.Realization
{
    public class CharacterControllerActorView : BaseActorView
    {
        [SerializeField] private CharacterControllerMovementComponent _characterController;

        public override IMovementComponent Movement => _characterController;

        private void OnCollisionEnter(Collision other)
        {
            OnCollisionHappened(other.gameObject);
        }
    }
}