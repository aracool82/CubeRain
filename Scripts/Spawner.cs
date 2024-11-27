using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CubePool))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private int minValue = -10;
    [SerializeField] private int maxValue = 10;
    [SerializeField, Range(0.1f, 1f)] private float _delay = 0.1f;

    private CubePool _cubePool;
    private Vector3 _spawnPosition;
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
            
            cube.gameObject.SetActive(true);
            cube.transform.position = GetRandomPosition();
            cube.transform.SetParent(transform);

            cube.Touched += OnReturnInPool;
        }
    }

    private void OnReturnInPool(Cube cube)
    {
        cube.Touched -= OnReturnInPool;
        cube.gameObject.SetActive(false);
        _cubePool.Add(cube);
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(minValue, maxValue + 1), 0, Random.Range(minValue, maxValue + 1)) +
               _spawnPosition;
    }
}