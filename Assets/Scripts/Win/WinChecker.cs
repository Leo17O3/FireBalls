using UnityEngine;

public class WinChecker : MonoBehaviour
{
    private WinPanal _winPanal;
    [SerializeField] private Tower _tower;

    private void Awake()
    {
        _winPanal = FindObjectOfType<WinPanal>();
        _winPanal.SetActive(false);
    }

    private void OnEnable()
    {
        _tower.SizeUpdated += CheckWin;
    }

    private void OnDisable()
    {
        _tower.SizeUpdated -= CheckWin;
    }

    //public void OnBulletCollised(Block block, int blocksCount)
    //{
    //    CheckWin(blocksCount);
    //}

    private void CheckWin(int blocksCount)
    {
        if (blocksCount <= 0)
        {
            _winPanal.SetActive(true);
        }
    }
}
