using UnityEngine;

[CreateAssetMenu(fileName = "footstepSnd_", menuName = "Audio/Footstep Sound", order = 1)]
public class FootstepSound : ScriptableObject
{
    public string soundName;
    public AudioClip[] sounds;
}