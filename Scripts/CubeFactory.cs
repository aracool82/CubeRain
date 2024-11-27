using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    public Cube Create()
    {
        return Instantiate(_cubePrefab);
    }
}
