using UnityEngine;

namespace Interfaces
{
    public interface IDeadable
    {
        void Dead();
        void Damage(Vector3 enemyPos, float cantidad, Elements.Element element);
    }
}
