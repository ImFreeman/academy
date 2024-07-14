using System;
using UnityEngine;

namespace Features.Player.Scripts.Realization
{
    public class PlayerInputHandler : IDisposable
    {
        private readonly PlayerSpawner _playerSpawner;
        private readonly InputHandler _inputHandler;

        private bool _playerSpawned;
        private PlayerFacade _currenPlayerFacade;

        public PlayerInputHandler(PlayerSpawner playerSpawner, InputHandler inputHandler)
        {
            _playerSpawner = playerSpawner;
            _inputHandler = inputHandler;
            
            _playerSpawner.ActorSpawned += OnActorSpawned;
        }

        private void OnActorSpawned(object sender, PlayerFacade e)
        {
            _inputHandler.KeyboardInputEvent += OnKeyboardInputEvent;
            _inputHandler.MouseInputEvent += OnMouseInputEvent;

            _currenPlayerFacade = e;
            _currenPlayerFacade.ActorDestroyed += FacadeOnActorDestroyed;

            _playerSpawned = true;
        }

        private void FacadeOnActorDestroyed(object sender, EventArgs e)
        {
            _currenPlayerFacade.ActorDestroyed -= FacadeOnActorDestroyed;
            if (_playerSpawned)
            {
                _inputHandler.KeyboardInputEvent -= OnKeyboardInputEvent;
                _inputHandler.MouseInputEvent -= OnMouseInputEvent;

                _playerSpawned = false;
            }
        }

        private void OnMouseInputEvent(object sender, Vector2 e)
        {
            _currenPlayerFacade.CameraRotation.Rotate(e);
        }

        private void OnKeyboardInputEvent(object sender, Vector2 e)
        {
            _currenPlayerFacade.Movement.Move(new Vector3(e.x, 0, e.y));
        }

        public void Dispose()
        {
            _playerSpawner.ActorSpawned -= OnActorSpawned;
            if (_playerSpawned)
            {
                _currenPlayerFacade.ActorDestroyed -= FacadeOnActorDestroyed;
                _inputHandler.KeyboardInputEvent -= OnKeyboardInputEvent;
                _inputHandler.MouseInputEvent -= OnMouseInputEvent;
            }
        }
    }
}