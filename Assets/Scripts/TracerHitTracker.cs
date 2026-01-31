using UnityEngine;

public class TracerHitTracker : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>() != null)
        {
            GameManager.ReportPlayerHit();
        }
    }
}
