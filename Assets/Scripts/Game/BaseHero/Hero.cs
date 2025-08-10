using UnityEngine;
using Game.BaseUnit;

namespace Game.BaseHero
{
    [RequireComponent(typeof(HeroMeleeAttacker))]
    [RequireComponent(typeof(HeroMovement))]
    [RequireComponent(typeof(Unit))]
    public class Hero : EnablerMonoBehaviour
    {
        private HeroMeleeAttacker _heroMeleeAttacker;
        private HeroMovement _heroMovement;
        private Unit _unit;

        private void Awake()
        {
            _heroMeleeAttacker = GetComponent<HeroMeleeAttacker>();
            _heroMovement = GetComponent<HeroMovement>();
            _unit = GetComponent<Unit>();
        }

        public void Initialize(int healthPoints)
        {
            _unit.Initialize(healthPoints);
            _unit.OnUnitDamage += Unit_OnUnitDamage;
            _unit.OnUnitDeath += Unit_OnUnitDeath;
            _heroMovement.OnMovementStart += OnMovementStart;
            _heroMovement.OnMovementEnd += OnMovementEnd;
            _heroMovement.Enable();
            _heroMeleeAttacker.Initialize();
            _heroMeleeAttacker.OnAttackPerformed += PlayerMeleeAttacker_OnAttackPerformed;
            Enable();
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
        
        protected void FaceToEnemyDirection(Vector3 directionToEnemy)
        {
            _unit.PlayAttackAnimation(directionToEnemy);
        }
    }
}