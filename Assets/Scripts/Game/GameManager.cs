using Game.BaseHero;
using Game.Input;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        void Start()
        {
            HeroManager.Instance.Initialize();
            Joystick.Instance.Initialize();
            TouchInputManager.Instance.Initialize();
            TouchInputManager.Instance.Enable();
            Joystick.Instance.Enable();
            
        }
    }
}
