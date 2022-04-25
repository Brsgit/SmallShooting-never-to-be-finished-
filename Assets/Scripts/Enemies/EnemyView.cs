namespace Enemy
{
    public abstract class EnemyView
    {
        protected Enemy _enemy;

        public void Initialize(Enemy enemy)
        {
            _enemy = enemy;
        }
    }
}