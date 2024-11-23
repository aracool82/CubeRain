using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CubePool))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private int minValue = -10;
    [SerializeField] private int maxValue = 10;
    [SerializeField,Range(0.05f,0.4f)] private float _delay = 0.1f;

    private Vector3 _spawnPosition;
    private CubePool _cubePool;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
        _cubePool = GetComponent<CubePool>();
        _spawnPosition = transform.position;
    }

    private void Start()
    {
        StartCoroutine(SpawnWithWait());
    }

    private IEnumerator SpawnWithWait()
    {
        while (true)
        {
            yield return _wait;
            
            Cube cube = _cubePool.Get();
            cube.Init(_cubePool);
            cube.transform.position = GetRandomPosition();
            cube.transform.SetParent(transform);
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(minValue, maxValue + 1), 0, Random.Range(minValue, maxValue + 1)) + _spawnPosition;
    }
}