using UnityEngine;

namespace Projectile
{
    [RequireComponent(typeof(Rigidbody), typeof(ProjectileView))]
    public class Projectile : MonoBehaviour, IShootable
    {
        private ProjectileView _view;
        private Rigidbody _rigidbody;
        public ProjectileFactory OrigingFactory { get; set; }

        public float Scale { get; private set; }
        public int Damage { get; private set; }
        public float Speed { get; private set; }
        public float LifeTime { get; private set; }

        private void Awake()
        {
            _view = GetComponent<ProjectileView>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Initialize(float scale, int damage, float speed, float lifeTime)
        {
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
            Damage = damage;
            Speed = speed;
            LifeTime = lifeTime;
            _view.Initialize(this);
        }

        private void Update()
        {
            LifeTime -= Time.deltaTime;
            if(LifeTime <= 0)
            {
                Deactivate();
            }
        }

        public void Shoot(Vector3 destination)
        {
            _rigidbody.velocity = (destination - transform.position).normalized * Speed;
        }

        public void Activate(Vector3 position)
        {
            gameObject.transform.position = new Vector3(position.x, position.y + 1.0f, position.z + 0.5f);
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            OrigingFactory.Reclaim(this);
        }
    }

}

