using Features.Core.Actor.Scripts.Interfaces;
using Features.Core.Movement.Scripts.Interfaces;

namespace Features.Player.Scripts.Interfaces
{
    public interface IPlayer : IActor
    {
        public ICameraRotation CameraRotation { get; set; }
    }
}