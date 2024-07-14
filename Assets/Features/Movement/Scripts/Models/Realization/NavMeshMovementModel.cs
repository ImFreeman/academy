using UnityEngine;

namespace Features.Core.Movement.Scripts.Models
{
    [CreateAssetMenu(fileName = "EnemyModel", menuName = "NavMeshMovementModels/EnemyModel", order = 1)]
    public class NavMeshMovementModel : ScriptableObject, IMovementModel
    {
        [SerializeField] private float _speed;
        public float Speed => _speed;
    }
}