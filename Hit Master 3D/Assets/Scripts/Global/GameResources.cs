using HitMaster.Attack;
using HitMaster.Health;
using UnityEngine;

namespace HitMaster.Global
{
    [CreateAssetMenu(menuName = "HitMaster/GameResources")]
    public class GameResources : ScriptableObject
    {
        [SerializeField] private HealthConfig _playerHealth;
        [SerializeField] private HealthConfig _enemyHealth;
        [SerializeField] private AttackConfig _playerAttack;
        [SerializeField] private AttackConfig _enemyAttack;

        public HealthConfig PlayerHealth => _playerHealth;
        public HealthConfig EnemyHealth => _enemyHealth;
        public AttackConfig PlayerAttack => _playerAttack;
        public AttackConfig EnemyAttack => _enemyAttack;
    }
}