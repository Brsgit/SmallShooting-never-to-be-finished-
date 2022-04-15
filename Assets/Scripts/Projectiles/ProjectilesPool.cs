using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPool : MonoBehaviour
{
    [SerializeField] private ProjectileFactory _factory;
    [SerializeField] private ProjectileType _type;

    private const int POOL_SIZE = 128;
    private Queue<Projectile> _pool = new Queue<Projectile>();

    private Transform _transform;

    private void Start()
    {
        _transform = transform;

        for (int i = 0; i < POOL_SIZE; i++)
        {
            var projectile = _factory.Get(_type, _transform);
            _pool.Enqueue(projectile);
        }
    }

    public IShootable GetItemFromQ()
    {
        var projectile = _pool.Dequeue();
        projectile.gameObject.SetActive(true);
        return projectile;
    }
}
