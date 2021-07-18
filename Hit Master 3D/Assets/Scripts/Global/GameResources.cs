using HitMaster.Attack;
using HitMaster.Pools;
using UnityEngine;

namespace HitMaster.Global
{
    [CreateAssetMenu(menuName = "HitMaster/GameResources")]
    public class GameResources : ScriptableObject
    {
        [SerializeField] private ProjectilePool _projectilePool;
        [SerializeField] private AttackConfig _playerAttack;

        public ProjectilePool ProjectilePool => _projectilePool;
        public AttackConfig PlayerAttack => _playerAttack;
    }
}