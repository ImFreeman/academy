using System;
using Features.Core.Actor.Scripts.Interfaces;

namespace Features.Enemy.Scripts.Realization
{
    public class EnemyStorageSpawnHandler : IDisposable
    {
        private readonly IActorStorage _actorStorage;
        private readonly IActorSpawner<Actor, NavMeshActorModel> _actorSpawner;

        public EnemyStorageSpawnHandler(IActorStorage actorStorage, IActorSpawner<Actor, NavMeshActorModel> actorSpawner)
        {
            _actorStorage = actorStorage;
            _actorSpawner = actorSpawner;
            
            _actorSpawner.ActorSpawned += OnActorSpawned;
        }

        private void OnActorSpawned(object sender, Actor e)
        {
            _actorStorage.Add(e);
        }

        public void Dispose()
        {
            _actorSpawner.ActorSpawned -= OnActorSpawned;
        }
    }
}