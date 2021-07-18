using HitMaster.Attack;
using HitMaster.Global;
using HitMaster.Pools;
using HitMaster.Units;
using UnityEngine;

namespace HitMaster.States
{
    public class AttackState : IState
    {
        private AttackConfig _attackConfig;
        private ProjectilePool _projectilePool;
        private Player _player;

        public AttackState(Player player)
        {
            _player = player;
        }

        public void Begin()
        {
            _attackConfig = General.Instance.GameResources.PlayerAttack;
            _projectilePool = General.Instance.GameResources.ProjectilePool;
        }

        public void End()
        {
            return;
        }

        public void OnClick()
        {
            var projectile = _projectilePool.Create();
            projectile.transform.position = _player.transform.position;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                projectile.Direction = (hit.point - _player.transform.position).normalized;
            }
            else
            {
                projectile.Direction = ray.direction.normalized;
            }
        }

        public void OnUpdate()
        {
            return;
        }
    }
}