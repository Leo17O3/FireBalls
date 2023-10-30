using UnityEngine;

public class WinChecker : MonoBehaviour
{
    private WinPanal _winPanal;

    private void Awake()
    {
        _winPanal = FindObjectOfType<WinPanal>();
        _winPanal.SetActive(false);
    }

    public void OnBulletCollised(Block block, int blocksCount)
    {
        CheckWin(blocksCount);
    }

    private void CheckWin(int blocksCount)
    {
        if (blocksCount <= 0)
        {
            _winPanal.SetActive(true);
        }
    }
}
