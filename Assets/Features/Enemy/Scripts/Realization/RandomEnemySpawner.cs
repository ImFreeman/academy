using System;
using Features.Core.Actor.Scripts.Interfaces;
using UnityEngine;

namespace Features.Enemy.Scripts.Realization
{
    public class RandomEnemySpawner : IActorSpawner<Actor, NavMeshActorModel>
    {
        private const float CoordY = 0.3f;

        private readonly NavMeshActorSpawner _actorSpawner;
        private readonly System.Random _random;
        private readonly Vector2Int _xRange;
        private readonly Vector2Int _zRange;

        public event EventHandler<Actor> ActorSpawned;
        
        public RandomEnemySpawner(NavMeshActorSpawner actorSpawner, Vector2Int xRange, Vector2Int zRange)
        {
            _random = new System.Random();
            _actorSpawner = actorSpawner;
            _xRange = xRange;
            _zRange = zRange;
        }
        
        public Actor Spawn(NavMeshActorModel model)
        {
            var actor = _actorSpawner.Spawn(model);
            var coordX = _random.Next(_xRange.x, _xRange.y);
            var coordZ = _random.Next(_zRange.x, _zRange.y);
            actor.View.BodyTransform.position = new Vector3(coordX, CoordY, coordZ);

            ActorSpawned?.Invoke(this, actor);
            
            return actor;
        }
    }
}