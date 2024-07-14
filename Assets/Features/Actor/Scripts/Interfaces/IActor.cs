using System;
using Features.Core.Health.Scripts.Interfaces;
using Features.Core.Movement.Scripts.Interfaces;
using Object = UnityEngine.Object;

namespace Features.Core.Actor.Scripts.Interfaces
{
    public interface IActor: IDisposable
    {
        public event EventHandler ActorDestroyed;
        public IHealth Health { get; set; }
        public IMovement Movement { get; set; }
        public IActorView View { get; set; }
        public int GetID();
    }
}