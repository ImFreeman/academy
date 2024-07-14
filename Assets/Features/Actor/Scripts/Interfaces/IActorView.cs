using System;
using Features.Core.Movement.Scripts.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Features.Core.Actor.Scripts.Interfaces
{
    public interface IActorView
    {
        public Transform BodyTransform { get; }
        public MeshRenderer MeshRenderer { get; }
        public IMovementComponent Movement { get; }
        public event EventHandler<GameObject> CollisionHappened;
    }
}