using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    private Vector3 _moveDirection;
    [SerializeField] private float _extentageForce;
    [SerializeField] private float _radius;
    [SerializeField] private float _lifeTimeAfterCollisionWithObstacle;
    private Tower _tower;

    private void Start()
    {
        _moveDirection = -transform.right;
        _tower = FindObjectOfType<Tower>();
    }
    private void Update()
    {
        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddExplosionForce(_extentageForce, transform.position + transform.right, _radius);
            _moveDirection = transform.right + transform.up;
            Destroy(gameObject, _lifeTimeAfterCollisionWithObstacle);
        }
        else if (other.TryGetComponent(out Block block))
        {
            block.BulletCollisied?.Invoke(block, _tower.BlocksCount);
            Destroy(gameObject);
        }
    }
}
