using DG.Tweening;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _gun;
    private Vector3 _startShootPoint;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _shootDelay;
    private float _timeAfterShoot;

    private void Start()
    {
        _startShootPoint = new Vector3(_gun.position.x - _gun.localScale.x, _gun.position.y, _gun.position.z);
    }
    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0) && _timeAfterShoot >= _shootDelay)
        {
            _timeAfterShoot = 0f;
            SpawnBullet();
            Move();
        }
    }

    private void Move()
    {
        transform.DOMoveX(transform.position.x + 0.5f, _shootDelay / 2f).SetLoops(2, LoopType.Yoyo);
    }

    private void SpawnBullet()
    {
        Instantiate(_bullet, _startShootPoint, Quaternion.identity);
    }
}
