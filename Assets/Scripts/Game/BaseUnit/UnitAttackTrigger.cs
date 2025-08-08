using UnityEngine;

namespace Game.BaseUnit
{
    public abstract class UnitAttackTrigger : EnablerMonoBehaviour
    {
        protected int _damage;

        public void Initialize(int damage)
        {
            _damage = damage;
            Enable();
        }
        
        public void SetScale(float scale)
        {
            transform.localScale = Vector3.one * scale;
        }

        protected abstract void OnTriggerStay(Collider other);
    }
}
