using Features.Core.Actor.Scripts.Interfaces;
using UnityEngine;

namespace Features.Player.Scripts.Interfaces
{
    public interface IPlayerView : IActorView
    {
        public Camera CameraObj { get; } 
    }
}