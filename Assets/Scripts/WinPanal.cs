using UnityEngine;

public class WinPanal : MonoBehaviour
{
    public void SetActive(bool isActve) => gameObject.SetActive(isActve);

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
