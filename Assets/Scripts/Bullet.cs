using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private void Update()
    {
        transform.Translate(-transform.right * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            block.BulletCollision?.Invoke(block);
            Destroy(gameObject);
        }
    }
}
