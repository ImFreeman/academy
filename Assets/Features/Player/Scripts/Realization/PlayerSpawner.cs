using System;
using Features.Core.Actor.Scripts.Interfaces;
using Features.Core.Movement.Scripts.Realization;

namespace Features.Player.Scripts.Realization
{
    public class PlayerSpawner : IActorSpawner<PlayerFacade, CharacterControllerActorModel>
    {
        private readonly CharacterControllerActorSpawner _characterControllerActorSpawner;

        public event EventHandler<PlayerFacade> ActorSpawned;
        
        public PlayerSpawner(CharacterControllerActorSpawner characterControllerActorSpawner)
        {
            _characterControllerActorSpawner = characterControllerActorSpawner;
        }

        public PlayerFacade Spawn(CharacterControllerActorModel model)
        {
            var actor = _characterControllerActorSpawner.Spawn(model);
            var playerView = actor.View as PlayerView;
            var playerActor = new PlayerFacade()
            {
                CameraRotation = new CameraRotation(playerView.BodyTransform, playerView.CameraObj.transform),
                Health = actor.Health,
                Movement = actor.Movement,
                View = actor.View
            };
            ActorSpawned?.Invoke(this, playerActor);

            return playerActor;
        }
    }
}