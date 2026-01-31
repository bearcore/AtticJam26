using Cinemachine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject GameOverUI;
    public GameObject StartUI;
    public GameObject SleepingScene;
    public GameObject WakeUpScene;
    public PlayableDirector WakeUpPlay;
    public PlayerController PlayerController;

    public CinemachineVirtualCamera VcamWakeUp;
    public CinemachineVirtualCamera VcamGameplay1;

    [HideInInspector] public static bool WaitingForStartClick = true;
    [HideInInspector] public bool WaitingForRestartClick = false;
    [HideInInspector] public bool IsGameOver = false;
    public bool IsPlayerInvulnerable = true;
    public float InitialInvunerabilityTimer = 2f;

    private int maximalPriority = 999999999;
    private CinemachineVirtualCamera prevCam;

    

    void Awake()
    {
        Instance = this;
        if(!WaitingForStartClick)
        {
            StartUI.SetActive(false);
        }
    }

    public void OnWakeUpPlayStopped(PlayableDirector director)
    {
        VcamWakeUp.Priority = 0;
        PlayerController.enabled = true;

        WakeUpPlay.stopped -= OnWakeUpPlayStopped;
    }

    void Update()
    {
        InitialInvunerabilityTimer -= Time.deltaTime;
        if(InitialInvunerabilityTimer <= 0f){
            IsPlayerInvulnerable = false;
        }
        
        if (WaitingForStartClick && Mouse.current.leftButton.wasPressedThisFrame)
        {
            SleepingScene.SetActive(false);
            WakeUpScene.SetActive(true);
            StartUI.SetActive(false);
            WaitingForStartClick = false;
        }

        if(WaitingForRestartClick && Mouse.current.leftButton.wasPressedThisFrame)
        {
            WaitingForRestartClick = false;
            SceneManager.LoadScene(0);
        }
    }

    public static void ReportPlayerHit()
    {
        Instance.ShowGameOverScreen();
    }

    private void ShowGameOverScreen()
    {
        if (IsGameOver) return;

        IsGameOver = true;

        if (GameOverUI) GameOverUI.SetActive(true);
        StartCoroutine(WaitBeforeClickAfterLoseScreen());
    }

    private IEnumerator WaitBeforeClickAfterLoseScreen()
    {
        yield return new WaitForSeconds(0.5f);
        WaitingForRestartClick = true;
    }

    public void PromoteCamera(CinemachineVirtualCamera vcam)
    {
        vcam.Priority = maximalPriority;
        if (prevCam) prevCam.Priority = 0;

        prevCam = vcam;
    }
}
