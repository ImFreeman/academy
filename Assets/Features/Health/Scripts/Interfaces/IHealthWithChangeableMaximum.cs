using System;

namespace Features.Core.Health.Scripts.Interfaces
{
    public interface IHealthWithChangeableMaximum : IHealth
    {
        public event EventHandler<float> MaxHealthChanged; 
        
        public void ChangeMaxHealth(float value);
    }
}