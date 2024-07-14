using Features.Core.Movement.Scripts.Interfaces;
using Features.Core.Movement.Scripts.Realization;
using UnityEngine;

namespace Features.Enemy.Scripts.Realization
{
    public class NavMeshActorView : BaseActorView
    {
        [SerializeField] private NavMeshMovementComponent _movement;
        public override IMovementComponent Movement => _movement;

        private void OnCollisionEnter(Collision other)
        {
            OnCollisionHappened(other.gameObject);
        }
    }
}