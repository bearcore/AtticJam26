using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimationController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator Animator;

    public AudioSource RunningBreathing;
    public AudioSource IdleBreathing;

    private bool _isRunning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _isRunning = agent.velocity.magnitude > 0.2f;
        Animator.SetBool("Moving", _isRunning);
        RunningBreathing.volume = _isRunning ? 1f : 0f;
        IdleBreathing.volume = _isRunning ? 0f : 1f;
    }
}
