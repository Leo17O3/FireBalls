using UnityEngine;
using UnityEngine.UI;

public class WritePlatformsCount : MonoBehaviour
{
    [SerializeField] private Text _infoText;

    private void Start()
    {
        Write(Progress.Instance.BlocksCount);
    }

    public void OnBulletCollised(Block block, int blocksCount)
    {
        Write(blocksCount);
    }

    private void Write(int blocksCount)
    {
        _infoText.text = "Осталось блоков: " + blocksCount;
    }
}
