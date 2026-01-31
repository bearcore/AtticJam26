using Cinemachine;
using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameManager game;

    private void Start()
    {
        // Ensure the game runs at normal time scale
        Time.timeScale = 1f;

        StartCoroutine(InitGame());
    }

    private IEnumerator InitGame()
    {
        yield return new WaitUntil(() => GameManager.Instance.gameObject != null);

        game = GameManager.Instance;
        game.IsGameOver = false;

        if (game.WaitingForStartClick == true)
        {
            game.WakeUpPlay.stopped += game.OnWakeUpPlayStopped;

            StartCoroutine(SetPlayerControl(false));
            StartCoroutine(SetPromoteCamera(game.VcamWakeUp));

        }
        else
        {
            StartCoroutine(SetScene(game.SleepingScene, true));
            StartCoroutine(SetScene(game.WakeUpScene, false));

            StartCoroutine(SetPlayerControl(true));


            StartCoroutine(SetPromoteCamera(game.VcamGameplay1));
        }
    }

    private IEnumerator SetPlayerControl(bool enable)
    {
        yield return new WaitUntil(() => game.PlayerController.gameObject != null);

        game.PlayerController.enabled = enable;
    }

    private IEnumerator SetPromoteCamera(CinemachineVirtualCamera vcam)
    {
        yield return new WaitUntil(() => vcam.gameObject != null);

        game.PromoteCamera(vcam);
    }

    private IEnumerator SetScene(GameObject scene, bool active)
    {
        yield return new WaitUntil(() => scene != null);

        scene.SetActive(active);
    }

}
