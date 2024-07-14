using System;
using Features.Core.Actor.Scripts.Interfaces;
using Features.Core.UpdateManager;
using Features.Player.Scripts.Realization;

namespace Features.Enemy.Scripts.Realization
{
    public class EnemyMovementHandler : IUpdatable
    {
        private readonly IActorSpawner<PlayerFacade, CharacterControllerActorModel> _playerSpawner;
        private readonly IActorStorage _actorStorage;

        private bool _isPlayerSpawned;
        private Actor _currentPlayer;
        
        public event EventHandler<IUpdatable> Destroyed;
        
        public EnemyMovementHandler(
            IActorSpawner<PlayerFacade, CharacterControllerActorModel> playerSpawner, 
            IActorStorage actorStorage
            )
        {
            _playerSpawner = playerSpawner;
            _actorStorage = actorStorage;

            _playerSpawner.ActorSpawned += OnPlayerActorSpawned;
        }
        
        public void Update()
        {
            if (!_isPlayerSpawned)
            {
                return;
            }
            foreach (var value in _actorStorage.Actors.Values)
            {
                value.Movement.Move(_currentPlayer.View.BodyTransform.position);
            }
        }

        private void OnPlayerActorSpawned(object sender, PlayerFacade e)
        {
            _isPlayerSpawned = true;
            _currentPlayer = e;
            
            _currentPlayer.ActorDestroyed += PlayerOnActorDestroyed;
        }

        private void PlayerOnActorDestroyed(object sender, EventArgs e)
        {
            _currentPlayer.ActorDestroyed -= PlayerOnActorDestroyed;
            if (_isPlayerSpawned)
            {
                _isPlayerSpawned = false;
            }
        }
        
        public void Dispose()
        {
            Destroyed?.Invoke(this, this);
            _playerSpawner.ActorSpawned -= OnPlayerActorSpawned;
        }
    }
}