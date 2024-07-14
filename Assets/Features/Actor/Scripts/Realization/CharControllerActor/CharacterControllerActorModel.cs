using Features.Core.Actor.Scripts.Interfaces;
using Features.Core.Health.Scripts.Models.Interfaces;
using Features.Core.Health.Scripts.Models.Realization;
using Features.Core.Movement.Scripts.Models;
using UnityEngine;

namespace Features.Player.Scripts.Realization
{
    [CreateAssetMenu(fileName = "PlayerModel", menuName = "CharacterControllerActorModels/PlayerModel", order = 1)]
    public class CharacterControllerActorModel : ScriptableObject, IActorModel
    {
        [SerializeField] private HealthModel _health;
        [SerializeField] private CharacterControllerMovementModel _movement;
        [SerializeField] private CharacterControllerActorView _view;

        public IHealthModel HealthModel => _health;
        public IMovementModel MovementModel => _movement;
        public IActorView ViewPrefab => _view;
    }
}