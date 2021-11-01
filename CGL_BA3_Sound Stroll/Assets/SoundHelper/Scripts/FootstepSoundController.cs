using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSoundController : MonoBehaviour
{
    [SerializeField] FootstepSound[] m_FootstepSounds;

    public AudioClip[] GetFootstepSounds(Transform pOriginObj)
    {
        string soundType = CheckGround(pOriginObj);
        for (int i = 0; i < m_FootstepSounds.Length; i++)
        {
            if (soundType == m_FootstepSounds[i].soundName)
                return m_FootstepSounds[i].sounds;
        }

        return null;
    }

    private string CheckGround(Transform pOriginObj)
    {
        string groundType = "footsteps_stone";
        
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(pOriginObj.position, transform.TransformDirection(Vector3.down), out hit, 1.0f))
        {
            if (hit.transform.tag.Contains("footsteps"))
                groundType = hit.transform.tag;
        }

        return groundType;
    }
}