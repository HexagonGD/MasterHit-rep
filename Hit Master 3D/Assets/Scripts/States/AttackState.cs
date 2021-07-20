using HitMaster.Attack;
using HitMaster.Global;
using HitMaster.Paths;
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

        public AttackState(Player player, Location location)
        {
            _player = player;
            location.LocationComplete += OnLocationComplete;
        }

        public void Begin()
        {
            _attackConfig = General.Instance.GameResources.PlayerAttack;
            _projectilePool = General.Instance.GameResources.ProjectilePool;
            _player.Animator.SetBool("IsAiming", true);
        }

        public void End()
        {
            _player.Model.localRotation = Quaternion.Euler(new Vector3(0, -15, 0));
        }

        private void Shot()
        {
            var projectile = _projectilePool.Create();
            projectile.transform.position = _player.GunPosition;
            projectile.Damage = _attackConfig.Damage;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                _player.Model.LookAt(hit.point);
                projectile.Direction = (hit.point - _player.GunPosition).normalized;
            }
            else
            {
                projectile.Direction = ray.direction.normalized;
            }
        }

        private void OnLocationComplete()
        {
            _player.SetState(new MoveState(_player));
        }

        public void OnUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shot();
            }
        }
    }
}