using System;
using Features.Core.Actor.Scripts.Interfaces;
using Features.Core.Health.Scripts.Interfaces;
using Features.Core.Movement.Scripts.Interfaces;
using UnityEngine.AI;
using Object = UnityEngine.Object;

namespace Features.Enemy.Scripts.Realization
{
    public class Actor : IActor
    {
        public event EventHandler ActorDestroyed;
        public IHealth Health { get; set; }
        public IMovement Movement { get; set; }
        public IActorView View { get; set; }

        public int GetID()
        {
            return View.BodyTransform.gameObject.GetInstanceID();
        }

        public void Dispose()
        {
            ActorDestroyed?.Invoke(this, EventArgs.Empty);
            Object.Destroy(View.BodyTransform.gameObject);
            Health.Dispose();
            Movement.Dispose();
        }
    }
}