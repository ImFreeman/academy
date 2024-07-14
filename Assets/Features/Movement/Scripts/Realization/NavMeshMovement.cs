using Features.Core.Movement.Scripts.Models;
using UnityEngine;

namespace Features.Core.Movement.Scripts.Realization
{
    public class NavMeshMovement : BaseMovement<NavMeshMovementComponent, NavMeshMovementModel>
    {
        public override float Speed
        {
            get => _movementComponent.Speed;
            set => _movementComponent.Speed = value;
        }
        public NavMeshMovement(
            NavMeshMovementComponent movementComponent,
            NavMeshMovementModel model
            ) : base(movementComponent, model)
        {
        }
        
        public override void Move(Vector3 value)
        {
            _movementComponent.Move(value);
        }

        public override void Dispose()
        { }
    }
}