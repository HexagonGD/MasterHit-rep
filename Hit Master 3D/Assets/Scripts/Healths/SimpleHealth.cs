using System;

namespace HitMaster.Health
{
    public class SimpleHealth : IUnitHealth
    {
        public event Action Dead;

        private int _currentHealth;

        public SimpleHealth(HealthConfig config)
        {
            _currentHealth = config.Health;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                Dead?.Invoke();
            }
        }
    }
}