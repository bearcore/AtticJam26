using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class DollyTrackMovement : MonoBehaviour
{
    //[SerializeField] private CinemachineSmoothPath path;
    //[SerializeField] private CinemachineDollyCart cart;

    [SerializeField] CinemachineVirtualCamera vcam;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private NavMeshAgent playerAgent;
    [SerializeField] private float smoothSpeed;

    private float velocity = 0.0f;

    private float minClamp = 0.5f;
    private float maxClamp = 5.0f;

    CinemachineTrackedDolly dolly;

    private void Start()
    {
        dolly = vcam.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    private void Update()
    {
        //var targetPosition = path.FindClosestPoint(playerTransform.position, 0, -1, 10);
        //cart.m_Position = Mathf.SmoothDamp(cart.m_Position, targetPosition, ref velocity, Time.deltaTime * smoothSpeed);


        float clampValue = Mathf.Clamp(playerAgent.destination.x - playerTransform.position.x, minClamp, maxClamp);

        float newPosition = Mathf.SmoothDamp(playerTransform.position.x, playerTransform.position.x + clampValue, ref velocity, smoothSpeed * Time.deltaTime);

        //float newPosition = Mathf.SmoothDamp(dolly.m_PathPosition, 200f, ref velocity, smoothSpeed * Time.deltaTime);


        dolly.m_PathPosition = newPosition;

        Debug.Log("New Position: " + newPosition);
    }
}
