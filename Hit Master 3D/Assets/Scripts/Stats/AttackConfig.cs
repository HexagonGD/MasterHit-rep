using UnityEngine;

namespace HitMaster.Attack
{
    [CreateAssetMenu(menuName = "HitMaster/AttackConfig")]
    public class AttackConfig : ScriptableObject
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _reload;

        public int Damage => _damage;
        public float Reload => _reload;
    }
}