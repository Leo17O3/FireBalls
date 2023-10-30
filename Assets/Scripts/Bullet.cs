using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _force;
    [SerializeField] private float _additiveDirectionZ;
    [SerializeField] private float _lifeTimeAfterCollisionWithObstacle;
    private Tower _tower;

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
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Vector3 direction = obstacle.transform.position - transform.position;
            direction.z *= _additiveDirectionZ;

            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(-direction * _force);
            Destroy(gameObject, _lifeTimeAfterCollisionWithObstacle);
        }
        else if (other.TryGetComponent(out Block block))
        {
            block.BulletCollisied?.Invoke(block, _tower.BlocksCount);
            Destroy(gameObject);
        }
    }
}
