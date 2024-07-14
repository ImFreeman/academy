using System;
using UnityEngine;

namespace Features.Core.Movement.Scripts.Models
{
    [CreateAssetMenu(fileName = "PlayerMovementModel", menuName = "MovementModels/PlayerMovememntModel", order = 1)]
    public class CharacterControllerMovementModel : ScriptableObject, ICharacterControllerMovementModel
    {
        [SerializeField] private float _speed;
        [SerializeField] public float _gravity;
        public float Speed => _speed;
        public float GravityValue => _gravity;
    }
}