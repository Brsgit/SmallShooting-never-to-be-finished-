using Navigation;
using Projectile;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(IRayProvider), typeof(ITargetProvider))]
public class PlayerController : StateMachine
{
    private WaypointsContainer _waypointsContainer;
    public WaypointsContainer Waypoints => _waypointsContainer;

    private ProjectilesPool _pool;
    public ProjectilesPool Pool => _pool;

    private NavMeshAgent _agent;
    public NavMeshAgent Agent => _agent;

    private IRayProvider _rayProvider;
    private ITargetProvider _targetProvider;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rayProvider = GetComponent<IRayProvider>();
        _targetProvider = GetComponent<ITargetProvider>();
    }

    private void Start()
    {
        SetState(new ReadyToShootState(this));
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
    }

    private void PerformShoot()
    {
        Ray ray = _rayProvider.CreateRay();
        Vector3 target = _targetProvider.HitCheck(ray);
        State.Shoot(target);
    }


}
