namespace Game.BaseHero
{
    public class HeroManager : EnablerMonoBehaviour
    {
        public static HeroManager Instance;
        
        private Hero _hero;

        private void Awake()
        {
            Instance = this;
        }

        public void Initialize()
        {
            _hero = FindObjectOfType<Hero>();
            _hero.Initialize(50);
        }
    }
}
