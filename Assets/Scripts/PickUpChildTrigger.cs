using UnityEngine;
using UnityEngine.Events;

public class PickUpChildTrigger : MonoBehaviour
{
    public UnityEvent OnPlayerEntered = new UnityEvent();

    private bool _didTrigger;

    void OnTriggerEnter(Collider other)
    {
        if(_didTrigger) return;
        if(other.GetComponent<PlayerController>() != null)
        {
            OnPlayerEntered.Invoke();
            _didTrigger = true;
        }
    }
}
