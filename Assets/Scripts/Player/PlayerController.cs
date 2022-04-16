using Navigation;
using Projectile;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(IRayProvider), typeof(ITargetProvider))]
[RequireComponent(typeof(PlayerView))]
public class PlayerController : StateMachine
{
    private WaypointController _waypointsController;
    public WaypointController WaypointsController => _waypointsController;

    private ProjectilePool _pool;
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
        SetState(new ReadyToShootState(this));
        _view.SetIdleAnimation();
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
        _view.SetRunAnimation();
    }

    private void PerformShoot()
    {
        Ray ray = _rayProvider.CreateRay();
        Vector3 target = _targetProvider.HitCheck(ray);
        State.Shoot(target);
    }


}
