using System;
using UnityEngine;
using Game.BaseUnit;

namespace Game.BaseEnemy
{
    [RequireComponent(typeof(Unit))]
    public class Enemy : EnablerMonoBehaviour
    {
        private Unit _unit;
        private Enemy _enemyPrefab;

        public Action<Enemy> OnDead;
        
        private void Awake()
        {
            _unit = GetComponent<Unit>();
        }

        public void Initialize(int healthPoints, Enemy enemyPrefab)
        {
            _unit.Initialize(healthPoints);
            _unit.OnUnitDamage += Unit_OnUnitDamage;
            _unit.OnUnitDeath += Unit_OnUnitDeath;
            _enemyPrefab = enemyPrefab;
            Enable();
        }

        private void Unit_OnUnitDeath()
        {
            OnDead?.Invoke(this);
        }

        private void Unit_OnUnitDamage()
        {
            
        }

        public void TakeDamage(int damage)
        {
            _unit.TakeDamage(damage);
        }

        public Enemy GetEnemyPrefab()
        {
            return _enemyPrefab;
        }
    }
}