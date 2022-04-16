using UnityEngine;

namespace Projectile
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour, IShootable
    {
        [SerializeField] private ProjectileView _view;

        private Rigidbody _rigidbody;
        public ProjectileFactory OrigingFactory { get; set; }

        public float Scale { get; private set; }
        public int Damage { get; private set; }
        public float Speed { get; private set; }
        public float LifeTime { get; private set; }

        private void Awake()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody>();
        }

        public void Initialize(float scale, int damage, float speed, float lifeTime)
        {
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
            Damage = damage;
            Speed = speed;
            LifeTime = lifeTime;
            _view.Initialize(this);
        }

        public void Shoot(Vector3 destination)
        {
            _rigidbody.velocity = destination.normalized * Speed;
        }
    }

}

