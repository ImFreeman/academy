using Features.Core.Health.Scripts.Models.Interfaces;
using Features.Core.Movement.Scripts.Models;
using UnityEngine;

namespace Features.Core.Actor.Scripts.Interfaces
{
    public interface IActorModel
    {
        public IHealthModel HealthModel { get; }
        public IMovementModel MovementModel { get; }
        public IActorView ViewPrefab { get; }
    }
}