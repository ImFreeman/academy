using Features.Core.Actor.Scripts.Interfaces;
using Features.Core.Health.Scripts.Models.Interfaces;
using Features.Core.Health.Scripts.Models.Realization;
using Features.Core.Movement.Scripts.Models;
using UnityEngine;

namespace Features.Enemy.Scripts.Realization
{
    [CreateAssetMenu(fileName = "EnemyModel", menuName = "NavMeshActorModels/EnemyModel", order = 1)]
    public class NavMeshActorModel : ScriptableObject, IActorModel
    {
        [SerializeField] private HealthModel _healthModel;
        [SerializeField] private NavMeshMovementModel _navMeshMovementModel;
        [SerializeField] private NavMeshActorView _viewPrefab;

        public IHealthModel HealthModel => _healthModel;
        public IMovementModel MovementModel => _navMeshMovementModel;
        public IActorView ViewPrefab => _viewPrefab;
    }
}