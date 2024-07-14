using Features.Player.Scripts.Interfaces;
using UnityEngine;

namespace Features.Player.Scripts.Realization
{
    public class PlayerView : CharacterControllerActorView, IPlayerView
    {
        [SerializeField] private Camera _camera;

        public Camera CameraObj => _camera;
    }
}