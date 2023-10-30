using UnityEngine;

public class ObstaclesRotator : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private float _rotateSpeed;
    private Vector3 _direction = Vector3.down;
    [SerializeField] private float _timeEditDirection;
    private float _timeAfterEditedDirection;


    private void Update()
    {
        _timeAfterEditedDirection += Time.deltaTime;

        if (_timeAfterEditedDirection >= _timeEditDirection)
        {
            _direction *= -1f;
            _timeAfterEditedDirection = 0f;
            _rotateSpeed += 12.5f;
        }

        transform.RotateAround(_tower.transform.position, _direction, _rotateSpeed * Time.deltaTime);
    }
}
