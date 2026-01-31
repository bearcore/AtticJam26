using UnityEngine;

public class TracerHitTracker : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(GameManager.Instance.IsGameOver) return;
        if(GameManager.Instance.IsPlayerInvulnerable) return;

        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            GameManager.ReportPlayerHit();
        }
    }
}
