using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Cube cube))
            if(cube.IsTouch == false)
                cube.SetIsTouch(true);
    }
}
