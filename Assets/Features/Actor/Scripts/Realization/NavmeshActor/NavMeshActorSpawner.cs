using System;
using Features.Core.Actor.Scripts.Interfaces;
using Features.Core.Health.Scripts.Realization;
using Features.Core.Movement.Scripts.Models;
using Features.Core.Movement.Scripts.Realization;
using Object = UnityEngine.Object;

namespace Features.Enemy.Scripts.Realization
{
    public class NavMeshActorSpawner : IActorSpawner<Actor, NavMeshActorModel>
    {
        public event EventHandler<Actor> ActorSpawned;

        public Actor Spawn(NavMeshActorModel model)
        {
            var view = Object.Instantiate(model.ViewPrefab as NavMeshActorView);
            var health = new Health(model.HealthModel);
            var movement = new NavMeshMovement(view.Movement as NavMeshMovementComponent, model.MovementModel as NavMeshMovementModel);
            var actor = new Actor
            {
                Health = health,
                Movement = movement,
                View = view
            };
            ActorSpawned?.Invoke(this, actor);
            
            return actor;
        }
    }
}