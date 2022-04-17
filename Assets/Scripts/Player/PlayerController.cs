using Navigation;
using Projectile;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Core
{
    [RequireComponent(typeof(NavMeshAgent), typeof(IRayProvider), typeof(ITargetProvider))]
    [RequireComponent(typeof(PlayerView))]
    public class PlayerController : StateMachine
    {
        [SerializeField] private WaypointController _waypointsController;
        public WaypointController WaypointsController => _waypointsController;

        [SerializeField] private ProjectilePool _pool;
        public ProjectilePool Pool => _pool;

        private NavMeshAgent _agent;
        public NavMeshAgent Agent => _agent;

        private PlayerView _view;

        private IRayProvider _rayProvider;
        private ITargetProvider _targetProvider;


        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _rayProvider = GetComponent<IRayProvider>();
            _targetProvider = GetComponent<ITargetProvider>();
            _view = GetComponent<PlayerView>();
        }

        private void Start()
        {
            SetShootingState();
        }

        private void OnEnable()
        {
            InputController.Instance.OnTouch += PerformShoot;
        }

        private void OnDisable()
        {
            InputController.Instance.OnTouch -= PerformShoot;
        }

        private void Move()
        {
            SetState(new MoveState(this));
            State.Move();
            StartCoroutine(ReachedDestination());
            _view.SetRunAnimation();
        }

        private void SetShootingState()
        {
            SetState(new ReadyToShootState(this));
            _view.SetIdleAnimation();
        }

        private void PerformShoot()
        {
            Vector3 target = _targetProvider.HitCheck(_rayProvider.CreateRay());
            State.Shoot(target);
        }

        private IEnumerator ReachedDestination()
        {
            yield return new WaitUntil(() => !_agent.pathPending && _agent.remainingDistance < 0.5f);
            SetShootingState();
        }
    }

}
