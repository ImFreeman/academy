using Features.Core.Movement.Scripts.Models;
using UnityEngine;

namespace Features.Core.Movement.Scripts.Realization
{
    public class CharacterControllerMovement : BaseMovement<CharacterControllerMovementComponent, CharacterControllerMovementModel>
    {
        private readonly float _gravity;
        private float _speed;

        public override float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public CharacterControllerMovement(
            CharacterControllerMovementComponent movementComponent,
            CharacterControllerMovementModel model) : base(movementComponent, model)
        {
            _speed = model.Speed;
            _gravity = model.GravityValue;
            
        }
        
        public override void Move(Vector3 value)
        {
            var movement = new Vector3(value.x * _speed, _gravity, value.z * _speed);
            _movementComponent.Move(_movementComponent.BodyTransform.rotation * movement * Time.deltaTime);
        }

        public override void Dispose()
        { }
    }
}