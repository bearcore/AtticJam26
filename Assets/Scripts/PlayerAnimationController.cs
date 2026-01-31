using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimationController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator Animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Animator.SetBool("Moving", agent.velocity.magnitude > 0.2f);
    }
}
