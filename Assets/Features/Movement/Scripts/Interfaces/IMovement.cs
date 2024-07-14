using System;
using UnityEngine;

namespace Features.Core.Movement.Scripts.Interfaces
{
    public interface IMovement : IDisposable
    {
        public float Speed { get; set; }
        public void Move(Vector3 value);
    }
}