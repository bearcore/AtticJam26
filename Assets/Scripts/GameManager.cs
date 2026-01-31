using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject GameOverUI;

    private bool _waitingForRestartClick;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if(_waitingForRestartClick && Mouse.current.leftButton.wasPressedThisFrame)
        {
            SceneManager.LoadScene(0);
        }
    }

    public static void ReportPlayerHit()
    {
        Instance.ShowGameOverScreen();
    }

    private void ShowGameOverScreen()
    {
        GameOverUI.SetActive(true);
        StartCoroutine(WaitBeforeClickAfterLoseScreen());
    }

    private IEnumerator WaitBeforeClickAfterLoseScreen()
    {
        yield return new WaitForSeconds(3f);
        _waitingForRestartClick = true;
    }
}
