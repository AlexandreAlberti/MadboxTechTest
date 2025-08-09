using System;
using System.Collections;
using Game.BaseEnemy;
using Game.Detector;
using UnityEngine;

namespace Game.BaseHero
{
    [RequireComponent(typeof(EnemyDetector))]
    [RequireComponent(typeof(HeroMovement))]
    public class HeroMeleeAttacker : EnablerMonoBehaviour
    {
        [SerializeField] private HeroAttackTrigger _heroAttackTrigger;
        [SerializeField] private float _attackingCooldown;
        [SerializeField] private int _attackDamage;
        [SerializeField] private int _attackRange;
        [SerializeField] private float _attackStartTime;
        
        private const int AttackTriggerFramesToRemainActive = 3;
        
        private Hero _hero;
        private HeroMovement _heroMovement;
        private EnemyDetector _enemyDetector;
        private float _attackTimer;
        private float _initialAttackRange;

        public Action<Vector3> OnAttackPerformed;

        private void Awake()
        {
            _hero = GetComponent<Hero>();
            _enemyDetector = GetComponent<EnemyDetector>();
            _heroMovement = GetComponent<HeroMovement>();
        }

        public void Initialize()
        {
            _enemyDetector.Initialize(_hero.transform, _attackRange);
            _attackTimer = _attackingCooldown;
        }
        
        private void Update()
        {
            if (!_isEnabled)
            {
                return;
            }
            
            _attackTimer -= Time.deltaTime;

            Enemy closestEnemy = _enemyDetector.GetClosestEnemy();
            
            if (_attackTimer <= 0.0f && !_heroMovement.IsMoving() && closestEnemy)
            {
                _attackTimer = _attackingCooldown;
                Vector3 vectorToEnemy = closestEnemy.transform.position - transform.position;
                Vector3 directionToEnemy = vectorToEnemy.normalized;
                OnAttackPerformed?.Invoke(directionToEnemy);
                StartCoroutine(AttackChoreography());
                float signedAngle = Vector3.SignedAngle(transform.forward, directionToEnemy, transform.up);
                _heroAttackTrigger.transform.localRotation = Quaternion.AngleAxis(signedAngle, Vector3.up);
            }
        }
        
        private IEnumerator AttackChoreography()
        {
            yield return new WaitForSeconds(_attackStartTime);
            _heroAttackTrigger.Enable();
            
            for (int i = 0; i < AttackTriggerFramesToRemainActive; i++)
            {
                yield return new WaitForEndOfFrame();
            }
            
            _heroAttackTrigger.Disable();
        }

        public void UpdateAttackRange(float attackRangeModifier)
        {
            _heroAttackTrigger.transform.localScale = new Vector3(attackRangeModifier, attackRangeModifier, attackRangeModifier);
        }
    }
}
