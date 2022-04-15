using System;

[Serializable]
class ProjectileConfig
{
    public Projectile Prefab;
    [FloatRangeSlider(0.1f, 10f)]
    public float Scale;
    public int Damage;
    [FloatRangeSlider(0.5f, 2f)]
    public float Speed;
    [FloatRangeSlider(0.5f, 2f)]
    public float LifeTime;
}
