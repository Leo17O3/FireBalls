using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    [SerializeField] private TowerBuilder _towerBuilder;
    [SerializeField] private WritePlatformsCount _writePlayformsCount;
    [SerializeField] private EffectInstantaitor _effectInstantaitor;
    [SerializeField] private float _downgradeSpeed;
    private List<Block> _blocks;
    public int BlocksCount => _blocks.Count - 1;

    private void Start()
    {
        _blocks = _towerBuilder.Build();

        foreach (Block block in _blocks)
        {
            block.BulletCollisied += _writePlayformsCount.OnBulletCollised;
            block.BulletCollisied += _effectInstantaitor.OnBulletCollised;
            block.BulletCollisied += OnBulletCollised;
        }
    }

    private void OnBulletCollised(Block block, int blocksCount)
    {
        _blocks.Remove(block);
        DowngradeBlocksPosition();
        Destroy(block.gameObject);
    }

    private void DowngradeBlocksPosition()
    {
        foreach (Block block in _blocks)
        {
            Vector3 newBlockPosition = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y, block.transform.position.z);

            block.transform.position = newBlockPosition;
        }
    }
}
