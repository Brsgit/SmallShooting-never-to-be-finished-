using Projectile;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] private ProjectilesPool _pool;

    private Camera _cam;

    private Vector3 _destination;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        var ray = _cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            _destination = hit.point;
        }
        else
        {
            _destination = ray.GetPoint(1000);
        }

        var projectile = _pool.GetItemFromQ();
        projectile.Shoot(_destination);
    }
}
