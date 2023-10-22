using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    [SerializeField] private TowerBuilder _towerBuilder;
    [SerializeField] private float _downgradeSpeed;
    private List<Block> _blocks;

    private void Start()
    {
        _blocks = _towerBuilder.Build();

        foreach (Block block in _blocks)
        {
            block.BulletCollision += OnBulletCollised;
        }
    }

    private void OnBulletCollised(Block block)
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
