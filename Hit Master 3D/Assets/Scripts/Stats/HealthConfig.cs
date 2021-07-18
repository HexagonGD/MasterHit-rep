using UnityEngine;

namespace HitMaster.Health
{
    [CreateAssetMenu(menuName = "HitMaster/HealthConfig")]
    public class HealthConfig : ScriptableObject
    {
        [SerializeField] private int _health;

        public int Health => _health;
    }
}