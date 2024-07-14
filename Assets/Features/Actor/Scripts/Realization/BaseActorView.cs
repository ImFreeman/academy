using System;
using Features.Core.Actor.Scripts.Interfaces;
using Features.Core.Movement.Scripts.Interfaces;
using UnityEngine;

namespace Features.Enemy.Scripts.Realization
{
    public abstract class BaseActorView : MonoBehaviour, IActorView
    {
        [SerializeField] private Transform _bodyTransform;
        [SerializeField] private MeshRenderer _meshRenderer;

        public Transform BodyTransform => _bodyTransform;
        public MeshRenderer MeshRenderer => _meshRenderer;
        
        public virtual IMovementComponent Movement { get; }

        public event EventHandler<GameObject> CollisionHappened;

        protected void OnCollisionHappened(GameObject go)
        {
            CollisionHappened?.Invoke(this, go);
        }
    }
}