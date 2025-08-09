using UnityEngine;
using Game.BaseUnit;

namespace Game.BaseHero
{
    [RequireComponent(typeof(HeroAttackTrigger))]
    [RequireComponent(typeof(HeroMovement))]
    [RequireComponent(typeof(Unit))]
    public class Hero : EnablerMonoBehaviour
    {
        [SerializeField] private GameObject[] _weapons;
        
        private HeroAttackTrigger _heroAttackTrigger;
        private HeroMovement _heroMovement;
        private Unit _unit;

        private void Awake()
        {
            _heroAttackTrigger = GetComponent<HeroAttackTrigger>();
            _heroMovement = GetComponent<HeroMovement>();
            _unit = GetComponent<Unit>();
        }

        public void Initialize(int healthPoints)
        {
            _unit.Initialize(healthPoints);
            _unit.OnUnitDamage += Unit_OnUnitDamage;
            _unit.OnUnitDeath += Unit_OnUnitDeath;

            foreach (GameObject weapon in _weapons)
            {
                weapon.SetActive(false);
            }
            
            Enable();
            ChangeWeapon(Random.Range(0, _weapons.Length));
            _heroMovement.Enable();
        }

        private void Unit_OnUnitDeath(Unit unit)
        {
            _unit.OnUnitDeath += Unit_OnUnitDeath;
        }

        private void Unit_OnUnitDamage()
        {
            // Not Implementing as not expected to receive any event here
        }

        public void ChangeWeapon(int index)
        {
            int indexToUse = index;
            
            if (index < 0)
            {
                indexToUse = 0;
            }

            if (index >= _weapons.Length)
            {
                indexToUse =  _weapons.Length - 1;
            }
            
            _weapons[indexToUse].SetActive(true);
        }
        
        protected void FaceToEnemyDirection(Vector3 directionToEnemy)
        {
            _unit.PlayAttackAnimation(directionToEnemy);
        }
    }
}