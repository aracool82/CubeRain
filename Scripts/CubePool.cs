using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    
    private Queue<Cube> _cubesPool = new Queue<Cube>();

    public Cube Get()
    {
        if (_cubesPool.Count == 0)
            Add(CreateCube());
        
        Cube cube = _cubesPool.Dequeue();
        cube.gameObject.SetActive(true);
        
        return cube;
    }

    public void Add(Cube cube)
    {
        if (cube is not null)
        {
            cube.gameObject.SetActive(false);
            _cubesPool.Enqueue(cube);
        }
    }

    private Cube CreateCube()
    {
        Cube cube = Instantiate(_cubePrefab);
        cube.gameObject.SetActive(false);
        return cube;
    }
}