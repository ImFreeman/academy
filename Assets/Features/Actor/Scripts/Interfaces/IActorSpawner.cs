using System;
using UnityEngine;

namespace Features.Core.Actor.Scripts.Interfaces
{
    public interface IActorSpawner<TActor, TActorModel> 
        where TActorModel : IActorModel
        where TActor : IActor
    {
        public event EventHandler<TActor> ActorSpawned; 
        public TActor Spawn(TActorModel model);
    }
}