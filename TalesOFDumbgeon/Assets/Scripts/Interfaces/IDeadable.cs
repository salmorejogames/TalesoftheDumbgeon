using UnityEngine;

namespace Interfaces
{
    public interface IDeadable
    {
        void Dead();
        void Damage(GameObject enemy, float cantidad, Elements.Element element);
    }
}
