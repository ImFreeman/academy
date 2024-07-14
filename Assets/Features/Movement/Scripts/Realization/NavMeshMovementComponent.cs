using Features.Core.Movement.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Features.Core.Movement.Scripts.Realization
{
    public class NavMeshMovementComponent : MonoBehaviour, IMovementComponent
    {
        [SerializeField] private NavMeshAgent _agent;

        public float Speed
        {
            get => _agent.speed;
            set => _agent.speed = value;
        }
        
        public void Move(Vector3 value)
        {
            _agent.destination = value;
        }
    }
}