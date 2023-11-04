using UnityEngine;
using UnityEngine.UI;

public class WritePlatformsCount : MonoBehaviour
{
    [SerializeField] private Text _infoText;
    [SerializeField] private Tower _tower;

    //private void Start()
    //{
    //    Write(Progress.Instance.BlocksCount);
    //}

    //public void OnBulletCollised(Block block, int blocksCount)
    //{
    //    Write(blocksCount);
    //}

    private void OnEnable()
    {
        _tower.SizeUpdated += Write;
    }

    private void OnDisable()
    {
        _tower.SizeUpdated -= Write;
    }

    private void Write(int blocksCount)
    {
        _infoText.text = "Осталось блоков: " + blocksCount;
    }
}
