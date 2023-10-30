using UnityEngine;
using UnityEngine.UI;

public class WritePlatformsCount : MonoBehaviour
{
    [SerializeField] private Text _infoText;

    public void OnBulletCollised(Block block, int blockCount)
    {
        _infoText.text = "Осталось блоков: " + blockCount;
    }
}
