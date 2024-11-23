using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    private CubePool _cubePool;
    private int _minDelay = 2;
    private int _maxDelay = 5;
    private int _delay;
    private WaitForSeconds _wait;
    
    public bool IsTouch { get; private set; }

    public void Init(CubePool cubePool) 
    {
        SetDelay();
        ChangeColor(Color.red);
        
        _cubePool = cubePool;
        _wait = new WaitForSeconds(_delay);
        IsTouch = false;
    }

    public void SetIsTouch(bool isTouch)
    {
        if (isTouch == true)
        {
            IsTouch = true;
            ChangeColor(Color.green);
            StartCoroutine(DisableWithDelay());
        }
    }

    private IEnumerator DisableWithDelay()
    {
        yield return _wait;
        _cubePool.Add(this);
    }

    private void SetDelay()
    {
        _delay = Random.Range(_minDelay, _maxDelay + 1);
    }

    private void ChangeColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}