using Features.Core.Health.Scripts.Models.Interfaces;
using UnityEngine;

namespace Features.Core.Health.Scripts.Models.Realization
{
    [CreateAssetMenu(fileName = "HealthModel", menuName = "HealthModels/HealthModel", order = 1)]
    public class HealthModel : ScriptableObject, IHealthModel
    {
        [SerializeField] private float _startHealth;
        [SerializeField] private float _maxHealth;

        public float StartHealth => _startHealth;

        public float MaxHealth => _maxHealth;
    }
}