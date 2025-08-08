using UnityEngine;
using Game.BaseUnit;

namespace Game.BaseHero
{
    [RequireComponent(typeof(Unit))]
    public class Hero : EnablerMonoBehaviour
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
            // Not Implementing as not expected to receive any event here
        }

        private void Unit_OnUnitDamage()
        {
            // Not Implementing as not expected to receive any event here
        }

    }
}