using System;
using UnityEngine;

namespace Game.BaseUnit
{
    [RequireComponent(typeof(UnitHealth))]
    [RequireComponent(typeof(UnitVisuals))]
    public class Unit : EnablerMonoBehaviour
    {
        private UnitHealth _unitHealth;
        private UnitVisuals _unitVisuals;

        public Action OnUnitDamage;
        public Action OnUnitDeath;

        private void Awake()
        {
            _unitHealth = GetComponent<UnitHealth>();
            _unitVisuals = GetComponent<UnitVisuals>();
        }

        public void Initialize(int healthPoints)
        {
            _unitHealth.Initialize(healthPoints);
            _unitHealth.OnDamageReceived += UnitHealth_OnDamageReceived;
            _unitHealth.OnDeath += UnitHealth_OnDeath;
            _unitVisuals.PlayIdleAnimation();
            Enable();
        }

        private void UnitHealth_OnDamageReceived()
        {
            _unitVisuals.PlayDamagedAnimation();
            OnUnitDamage?.Invoke();
        }

        private void UnitHealth_OnDeath()
        {
            Disable();
            _unitVisuals.PlayDieAnimation();
            OnUnitDeath.Invoke();
        }
    }
}