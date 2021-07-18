using System;

namespace HitMaster.Health
{
    public interface IUnitHealth
    {
        event Action Dead;
        void TakeDamage(int damage);
    }
}