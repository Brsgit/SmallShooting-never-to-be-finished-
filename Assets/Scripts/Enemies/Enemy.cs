using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyView))]
    public abstract class Enemy : MonoBehaviour, IDamageable
    {
        private EnemyView _view;

        public EnemyFactory OriginFactoru { get; set; }

        private int _health;
        public int Health => _health;

        private void Awake()
        {
            _view = GetComponent<EnemyView>();
        }

        public void Initialize()
        {
            _view.Initialize(this);
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
        }
    }

}
