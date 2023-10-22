using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    private Vector3 _spawnPoint;
    [SerializeField] private Block _block;
    [SerializeField] private int _blockCount;

    public List<Block> Build()
    {
        List<Block> blocks = new List<Block>();

        for (int i = 0; i < _blockCount; i++)
        {
            Block block = BuildBlock();
            blocks.Add(block);
            _spawnPoint = block.transform.position;
        }

        return blocks;
    }

    private Block BuildBlock()
    {
        return Instantiate(_block, BlockSpawnPoint(), Quaternion.identity, transform);
    }

    private Vector3 BlockSpawnPoint()
    {
        _spawnPoint.y += _block.transform.localScale.y;

        return _spawnPoint;
    }
}
