using UnityEngine;
using Game.BaseUnit;

namespace Game.BaseHero
{
    [RequireComponent(typeof(HeroAttackTrigger))]
    [RequireComponent(typeof(HeroMeleeAttacker))]
    [RequireComponent(typeof(HeroMovement))]
    [RequireComponent(typeof(Unit))]
    public class Hero : EnablerMonoBehaviour
    {
        [SerializeField] private GameObject[] _weapons;
        [SerializeField] private int[] _weaponsDamages;
        
        private HeroAttackTrigger _heroAttackTrigger;
        private HeroMeleeAttacker _heroMeleeAttacker;
        private HeroMovement _heroMovement;
        private Unit _unit;

        private void Awake()
        {
            _heroAttackTrigger = GetComponent<HeroAttackTrigger>();
            _heroMeleeAttacker = GetComponent<HeroMeleeAttacker>();
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
            
            _heroMovement.OnMovementStart += OnMovementStart;
            _heroMovement.OnMovementEnd += OnMovementEnd;
            _heroMovement.Enable();
            _heroMeleeAttacker.Enable();
            _heroMeleeAttacker.OnAttackPerformed += PlayerMeleeAttacker_OnAttackPerformed;
        }

        private void OnMovementStart()
        {
            _unit.PlayMoveAnimation();
        }

        private void OnMovementEnd()
        {
            _unit.PlayIdleAnimation();
        }

        private void PlayerMeleeAttacker_OnAttackPerformed(Vector3 directionToEnemy)
        {
            FaceToEnemyDirection(directionToEnemy);
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
            _heroAttackTrigger.Initialize(_weaponsDamages[indexToUse]);
            _heroMeleeAttacker.Initialize();
        }
        
        protected void FaceToEnemyDirection(Vector3 directionToEnemy)
        {
            _unit.PlayAttackAnimation(directionToEnemy);
        }
    }
}