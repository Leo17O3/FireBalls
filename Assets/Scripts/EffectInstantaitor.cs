using UnityEngine;

public class EffectInstantaitor : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEffect;
    [SerializeField] private float _lifeTime;

    public void OnBulletCollised(Block block, int blockCount)
    {
       Destroy(Instantiate(_destroyEffect, block.transform.position, Quaternion.Euler(-90, 0, 0)), _lifeTime);
    }
}
