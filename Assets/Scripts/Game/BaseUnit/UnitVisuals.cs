using UnityEngine;

namespace Game.BaseUnit
{
    public class UnitVisuals : MonoBehaviour
    {
        private static readonly int ATTACK_ANIMATION = Animator.StringToHash("Attack");
        private static readonly int DAMAGE_ANIMATION = Animator.StringToHash("Damage");
        private static readonly int DIE_ANIMATION = Animator.StringToHash("Die");
        private static readonly int IDLE_ANIMATION = Animator.StringToHash("Idle");
        private static readonly int MOVE_ANIMATION = Animator.StringToHash("Move");
        
        [SerializeField] private Transform _visuals;
        [SerializeField] private Animator _animator;
        
        public void PlayDamagedAnimation()
        {
            _animator.Play(DAMAGE_ANIMATION);
        }
        
        public void PlayDieAnimation()
        {
            _animator.Play(DIE_ANIMATION);
        }

        public void PlayIdleAnimation()
        {
            _animator.Play(IDLE_ANIMATION);
        }

        public void PlayMoveAnimation()
        {
            _animator.Play(MOVE_ANIMATION);
        }

        public void PlayAttackAnimation(Vector3 forwardDirection, Vector3 directionToEnemy)
        {
            float signedAngle = Vector3.SignedAngle(forwardDirection, directionToEnemy, Vector3.up);
            _visuals.localRotation = Quaternion.AngleAxis(signedAngle, Vector3.up);
            _animator.Play(ATTACK_ANIMATION);
        }
    }
}
