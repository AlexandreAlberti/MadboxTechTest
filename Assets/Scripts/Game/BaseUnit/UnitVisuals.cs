using UnityEngine;

namespace Game.BaseUnit
{
    public class UnitVisuals : MonoBehaviour
    {
        private static readonly int DAMAGE_ANIMATION_TRIGGER = Animator.StringToHash("Damage");
        private static readonly int DIE_ANIMATION_TRIGGER = Animator.StringToHash("Die");
        private static readonly int IDLE_ANIMATION_TRIGGER = Animator.StringToHash("Idle");
        private static readonly int MOVE_ANIMATION_TRIGGER = Animator.StringToHash("Move");
        
        [SerializeField] private Animator _animator;
        
        public void PlayDamagedAnimation()
        {
            _animator.Play(DAMAGE_ANIMATION_TRIGGER);
        }
        
        public void PlayDieAnimation()
        {
            _animator.Play(DIE_ANIMATION_TRIGGER);
        }

        public void PlayIdleAnimation()
        {
            _animator.Play(IDLE_ANIMATION_TRIGGER);
        }

        public void PlayMoveAnimation()
        {
            _animator.Play(MOVE_ANIMATION_TRIGGER);
        }
    }
}
