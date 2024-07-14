using System;

namespace Features.Core.Health.Scripts.Interfaces
{
    public interface IHealth : IDisposable
    {
        public float CurrentHealth { get; }
        public float MaxHealth { get; }

        public event EventHandler<float> HealthChanged;
        public event EventHandler DeathHappened; 
        
        public void ChangeHealth(float delta);
    }
}