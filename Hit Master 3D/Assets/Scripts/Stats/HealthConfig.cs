using UnityEngine;

namespace HitMaster.Stats
{
    [CreateAssetMenu(menuName = "HitMaster/HealthConfig")]
    public class HealthConfig : ScriptableObject
    {
        [SerializeField] private int _health;

        public int Health => _health;
    }
}