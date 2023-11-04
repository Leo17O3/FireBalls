using UnityEngine;

public class EffectInstantaitor : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEffect;
    [SerializeField] private float _lifeTime;

    public void OnBulletCollised(Block block)
    {
        InstantiateAndDestroyEffect(block);
    }

    private void InstantiateAndDestroyEffect(Block block)
    {
        ParticleSystemRenderer particleSystemRenderer = Instantiate(_destroyEffect, block.transform.position, Quaternion.Euler(-90, 0, 0)).GetComponent<ParticleSystemRenderer>();
        particleSystemRenderer.material.color = block.GetComponent<MeshRenderer>().material.color;
    }
}
