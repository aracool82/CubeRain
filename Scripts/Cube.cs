using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private CubePool _cubePool;
    private WaitForSeconds _wait;
    
    private int _minDelay = 2;
    private int _maxDelay = 5;
    private float _delay;

    private bool _isTouch;

    public bool IsTouch
    {
        get => _isTouch;
        private set
        {
            if (value == true)
                _renderer.material.color = Color.green;
            else
                _renderer.material.color = Color.red;
            
            SetDelay();
            _isTouch = value;
        }
    }

    public event Action<Cube> Touched;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        IsTouch = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
            Touch();
    }

    private void Touch()
    {
        IsTouch = true;
        StartCoroutine(DisableWithDelay());
    }

    private IEnumerator DisableWithDelay()
    {
        yield return _wait;
        Touched?.Invoke(this);
    }

    private void SetDelay()
    {
        _delay = Random.Range(_minDelay, _maxDelay + 1);
        _wait = new WaitForSeconds(_delay);
    }
}