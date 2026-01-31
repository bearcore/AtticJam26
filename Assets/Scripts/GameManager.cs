using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject GameOverUI;
    public bool IsPlayerInvulnerable = true;
    public float InitialInvunerabilityTimer = 2f;

    private bool _waitingForRestartClick;
    private bool _didDie;

    public bool DidDie => _didDie;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        InitialInvunerabilityTimer -= Time.deltaTime;
        if(InitialInvunerabilityTimer <= 0f){
            IsPlayerInvulnerable = false;
        }

        if(_waitingForRestartClick && Mouse.current.leftButton.wasPressedThisFrame)
        {
             _waitingForRestartClick = false;
            SceneManager.LoadScene(0);
        }
    }

    public static void ReportPlayerHit()
    {
        Instance.ShowGameOverScreen();
    }

    private void ShowGameOverScreen()
    {
        if(_didDie) return;
        _didDie = true;
        GameOverUI.SetActive(true);
        StartCoroutine(WaitBeforeClickAfterLoseScreen());
    }

    private IEnumerator WaitBeforeClickAfterLoseScreen()
    {
        yield return new WaitForSeconds(3f);
        _waitingForRestartClick = true;
    }
}
