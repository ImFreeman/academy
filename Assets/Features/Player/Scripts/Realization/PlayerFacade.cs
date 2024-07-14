using Features.Core.Movement.Scripts.Interfaces;
using Features.Enemy.Scripts.Realization;
using Features.Player.Scripts.Interfaces;

namespace Features.Player.Scripts.Realization
{
    public class PlayerFacade : Actor, IPlayer
    {
        public ICameraRotation CameraRotation { get; set; }
    }
}