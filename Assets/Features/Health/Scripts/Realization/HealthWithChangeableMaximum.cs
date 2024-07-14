using System;
using Features.Core.Health.Scripts.Interfaces;
using Features.Core.Health.Scripts.Models.Interfaces;

namespace Features.Core.Health.Scripts.Realization
{
    public class HealthWithChangeableMaximum : Health, IHealthWithChangeableMaximum
    {
        public event EventHandler<float> MaxHealthChanged;
        
        public HealthWithChangeableMaximum(IHealthModel model) : base(model)
        {
        }
        
        public void ChangeMaxHealth(float value)
        {
            _maxHealth = value;
            MaxHealthChanged?.Invoke(this, _maxHealth);
            ChangeHealth(0.0f);
        }
    }
}