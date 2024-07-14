using System;
using Features.Core.Actor.Scripts.Interfaces;
using Features.Core.Health.Scripts.Realization;
using Features.Core.Movement.Scripts.Models;
using Features.Core.Movement.Scripts.Realization;
using Features.Enemy.Scripts.Realization;
using Object = UnityEngine.Object;

namespace Features.Player.Scripts.Realization
{
    public class CharacterControllerActorSpawner : IActorSpawner<Actor, CharacterControllerActorModel>
    {
        public event EventHandler<Actor> ActorSpawned;

        public Actor Spawn(CharacterControllerActorModel model)
        {
            var view = Object.Instantiate(model.ViewPrefab as CharacterControllerActorView);
            var health = new Health(model.HealthModel);
            var movement = new CharacterControllerMovement(
                view.Movement as CharacterControllerMovementComponent,
                model.MovementModel as CharacterControllerMovementModel
                );
            var actor = new Actor()
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