using HitMaster.Global;
using HitMaster.Units;
using UnityEngine;

namespace HitMaster
{
    public class Projectile : MonoBehaviour
    {
        public Vector3 Direction { get; set; }
        public int Damage { get; set; }

        [SerializeField] private float _speed;

        private void Update()
        {
            transform.Translate(Direction * Time.deltaTime * _speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            var enemy = other.GetComponent<Enemy>();
            enemy?.TakeDamage(Damage);
            General.Instance.GameResources.ProjectilePool.Recycle(this);
        }
    }
}