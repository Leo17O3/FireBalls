using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private float _moveSpeed;

    private void Start()
    {
        _tower = FindObjectOfType<Tower>();
    }
    private void Update()
    {
        transform.Translate(-transform.right * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            block.BulletCollisied?.Invoke(block, _tower.BlocksCount);
            Destroy(gameObject);
        }
    }
}
