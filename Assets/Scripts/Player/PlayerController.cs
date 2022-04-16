using Navigation;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(IRayProvider), typeof(ITargetProvider))]
public class PlayerController : StateMachine
{
    public WaypointsContainer Waypoints;

    private IRayProvider _rayProvider;
    private ITargetProvider _targetProvider;

    private void Awake()
    {
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
        State.Shoot();
    }


}
