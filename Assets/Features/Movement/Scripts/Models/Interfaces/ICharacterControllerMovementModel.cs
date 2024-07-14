namespace Features.Core.Movement.Scripts.Models
{
    public interface ICharacterControllerMovementModel : IMovementModel
    {
        public float GravityValue { get; }
    }
}