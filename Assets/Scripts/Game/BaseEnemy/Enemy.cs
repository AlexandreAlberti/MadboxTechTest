using UnityEngine;
using Game.BaseUnit;

namespace Game.BaseEnemy
{
    [RequireComponent(typeof(Unit))]
    public class Enemy : EnablerMonoBehaviour
    {
        private Unit _unit;

        private void Awake()
        {
            _unit = GetComponent<Unit>();
        }

        public void Initialize(int healthPoints)
        {
            _unit.Initialize(healthPoints);
            _unit.OnUnitDamage += Unit_OnUnitDamage;
            _unit.OnUnitDeath += Unit_OnUnitDeath;
            Enable();
        }

        private void Unit_OnUnitDeath()
        {
            
        }

        private void Unit_OnUnitDamage()
        {
            
        }
    }
}