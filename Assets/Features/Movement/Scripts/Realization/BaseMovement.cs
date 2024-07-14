using Features.Core.Movement.Scripts.Interfaces;
using Features.Core.Movement.Scripts.Models;
using UnityEngine;

namespace Features.Core.Movement.Scripts.Realization
{
    public abstract class BaseMovement<TMovementComponent, TMovementModel> : IMovement 
        where TMovementComponent : IMovementComponent
        where TMovementModel : IMovementModel
    {
        protected readonly TMovementComponent _movementComponent;
        public abstract float Speed { get; set; }
        
        protected BaseMovement(
            TMovementComponent movementComponent,
            TMovementModel model)
        {
            _movementComponent = movementComponent;
            Speed = model.Speed;
        }
        
        public abstract void Move(Vector3 value);

        public abstract void Dispose();
    }
}