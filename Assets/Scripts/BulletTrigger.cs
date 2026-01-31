using Unity.VisualScripting;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    public GameObject ActivateOnEnter;

    void OnTriggerEnter(Collider other)
    {
        var controller = other.gameObject.GetComponent<PlayerController>();
        if(controller != null)
        {
            ActivateOnEnter.SetActive(true);
        }
    }

    /*void OnTriggerExit(Collider other)
    {
        var controller = other.gameObject.GetComponent<PlayerController>();
        if(controller != null)
        {
            ActivateOnEnter.SetActive(false);
        }
    }*/
}
