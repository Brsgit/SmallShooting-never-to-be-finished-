using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action OnTouch;

    private float _nextInput = 0;

    private const float TOUCH_COOLDAWN = 1.0f;

    public static InputController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        _nextInput += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && _nextInput > TOUCH_COOLDAWN)
        {
            _nextInput = 0;
            OnTouch?.Invoke();
        }
    }
}
