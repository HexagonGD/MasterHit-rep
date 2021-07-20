using HitMaster.Health;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace HitMaster.Units
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Enemy : MonoBehaviour
    {
        public event Action Dead;

        private IUnitHealth _unitHealth;
        [SerializeField] private Slider _hpSlider;
        [SerializeField] private HealthConfig _config;

        private void Awake()
        {
            _unitHealth = new SliderHealth(_config, _hpSlider);
            _unitHealth.Dead += OnDead;
            SetRigidbodyState(true);
            SetColliderState(false);
        }

        public void TakeDamage(int damage)
        {
            _unitHealth.TakeDamage(damage);
        }

        private void OnDead()
        {
            Dead?.Invoke();
            GetComponent<Animator>().enabled = false;
            SetRigidbodyState(false);
            SetColliderState(true);
            Destroy(this);
        }

        private void SetRigidbodyState(bool state)
        {
            var rigids = GetComponentsInChildren<Rigidbody>();
            foreach (var i in rigids)
            {
                i.isKinematic = state;
            }
            GetComponent<Rigidbody>().isKinematic = !state;
        }

        private void SetColliderState(bool state)
        {
            var colliders = GetComponentsInChildren<Collider>();
            foreach (var i in colliders)
            {
                i.enabled = state;
            }
            GetComponent<Collider>().enabled = !state;
        }
    }
}