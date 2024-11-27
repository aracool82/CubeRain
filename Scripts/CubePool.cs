using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeFactory))]
public class CubePool : MonoBehaviour
{
    private CubeFactory _cubeFactory;
    private Queue<Cube> _cubesPool = new Queue<Cube>();

    private void Awake()
    {
        _cubeFactory = GetComponent<CubeFactory>();
    }

    public Cube Get()
    {
        if (_cubesPool.Count == 0)
            Add(_cubeFactory.Create());

        return _cubesPool.Dequeue();;
    }

    public void Add(Cube cube)
    {
        if (cube is not null)
            _cubesPool.Enqueue(cube);
    }
}