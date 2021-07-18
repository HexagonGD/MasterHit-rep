using System;
using UnityEngine.UI;

namespace HitMaster.Health
{
    public class SliderHealth : IUnitHealth
    {
        private readonly Slider _slider;

        private HealthConfig _healthConfig;
        private int _currentHealth;

        public event Action Dead;

        public SliderHealth(HealthConfig config, Slider slider)
        {
            _healthConfig = config;
            _currentHealth = config.Health;
            _slider = slider;
            Show();
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if(_currentHealth <= 0)
            {
                Dead?.Invoke();
                Hide();
            }
            else
            {
                Show();
            }
        }

        private void Show()
        {
            _slider.enabled = true;
            _slider.value = _currentHealth / _healthConfig.Health;
        }

        private void Hide()
        {
            _slider.enabled = false;
        }
    }
}