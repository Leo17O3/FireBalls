using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Tower _tower;

    private void Update()
    {
        transform.RotateAround(_tower.transform.position, Vector3.down, 0.5f);
    }
}
