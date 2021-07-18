using HitMaster.Global;
using System.Collections.Generic;
using UnityEngine;

namespace HitMaster.Pools
{
    [CreateAssetMenu(menuName = "HitMaster/ProjectilePool")]
    public class ProjectilePool : ScriptableObject
    {
        [SerializeField] private Projectile _projectilePrefab;
        private Queue<Projectile> _projectiles = new Queue<Projectile>();
        [SerializeField] Transform _parent;

        public Projectile Create()
        {
            var projectile = _projectiles.Count == 0 ?
                Object.Instantiate(_projectilePrefab) :
                _projectiles.Dequeue();
            //projectile.transform.SetParent(null);
            projectile.gameObject.SetActive(true);
            return projectile;
        }

        public void Recycle(Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
            //projectile.transform.SetParent(_parent);
            _projectiles.Enqueue(projectile);
        }
    }
}