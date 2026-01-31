using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class DollyTrackMovement : MonoBehaviour
{
    //[SerializeField] private CinemachineSmoothPath path;
    //[SerializeField] private CinemachineDollyCart cart;

    public LerpMovement lerpMovement;

    //[SerializeField] CinemachineVirtualCamera vcam;
    //public Rigidbody cameraRB;
    public Transform cameraTF;

    [SerializeField] private Transform playerTransform;
    //[SerializeField] private NavMeshAgent playerAgent;
    //[SerializeField] private float smoothSpeed;

    private float velocity = 0.0f;

    private float minClamp = 0.5f;
    private float maxClamp = 5.0f;

    CinemachineTrackedDolly dolly;

    private void Start()
    {
        //dolly = vcam.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    private void Update()
    {
        //var targetPosition = path.FindClosestPoint(playerTransform.position, 0, -1, 10);
        //cart.m_Position = Mathf.SmoothDamp(cart.m_Position, targetPosition, ref velocity, Time.deltaTime * smoothSpeed);


        float dirf = (cameraTF.position - playerTransform.position).z;

        if (dirf > 0.1f)
            lerpMovement.MoveTo(new Vector3(0f, 0f, playerTransform.position.z), Mathf.Abs(dirf));
        else if (dirf < -0.1f)
            lerpMovement.MoveTo(new Vector3(0f, 0f, playerTransform.position.z), Mathf.Abs(dirf));
     

        //float clampValue = Mathf.Clamp(playerAgent.destination.x - playerTransform.position.x, minClamp, maxClamp);

        //float newPosition = Mathf.SmoothDamp(playerTransform.position.x, playerTransform.position.x + playerAgent.velocity.x, ref velocity, smoothSpeed * Time.deltaTime);

        //float newPosition = Mathf.SmoothDamp(dolly.m_PathPosition, 200f, ref velocity, smoothSpeed * Time.deltaTime);


        //dolly.m_PathPosition = newPosition;

        //Debug.Log("New Position: " + newPosition);
    }
}
