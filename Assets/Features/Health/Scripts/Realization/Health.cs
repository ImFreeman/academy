using System;
using Features.Core.Health.Scripts.Interfaces;
using Features.Core.Health.Scripts.Models.Interfaces;

namespace Features.Core.Health.Scripts.Realization
{
    public class Health : IHealth
    {
        protected float _currentHealth;
        protected float _maxHealth;

        public float CurrentHealth => _currentHealth;
        public float MaxHealth => _maxHealth;

        public event EventHandler<float> HealthChanged;
        public event EventHandler DeathHappened;

        public Health(IHealthModel model)
        {
            _currentHealth = model.StartHealth;
            _maxHealth = model.MaxHealth;
        }
        
        public virtual void ChangeHealth(float delta)
        {
            _currentHealth = Math.Clamp(_currentHealth + delta, 0.0f, _maxHealth);
            HealthChanged?.Invoke(this, _currentHealth);
            if (_currentHealth <= 0.0f)
            {
                DeathHappened?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Dispose()
        { }
    }
}