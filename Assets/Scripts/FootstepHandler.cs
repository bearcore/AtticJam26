using System.Collections.Generic;
using UnityEngine;

public class FootstepHandler : MonoBehaviour
{
    public AudioSource Source;
    public List<AudioClip> Clips;
    public void Footstep()
    {
        Source.clip = GetRandom(Clips);
        Source.Play();
    }

    private AudioClip GetRandom(List<AudioClip> clips)
    {
        var index = Random.Range(0, clips.Count);
        return clips[index];
    }
}
