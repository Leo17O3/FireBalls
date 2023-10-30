using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButton : MonoBehaviour
{
    [SerializeField] private WinPanal _winPanal;

    public void OnClick()
    {
        Progress.Instance.BlocksCount += 2;
        _winPanal.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }
}
