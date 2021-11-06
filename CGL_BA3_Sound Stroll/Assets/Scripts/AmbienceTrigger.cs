using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceTrigger : MonoBehaviour
{
    AmbienceSwitcher ambienceSwitcher;

    private void Start()
    {
        ambienceSwitcher = FindObjectOfType<AmbienceSwitcher>();
    }
    public enum AmbienceMode 
    {
    WINDY,
    BACKYARD
    }
    public AmbienceMode ambienceMode;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (ambienceMode == AmbienceMode.WINDY)
            {
                if (ambienceSwitcher != null)
                {
                    ambienceSwitcher.IsWindy = true;
                }
            }
            else if (ambienceMode == AmbienceMode.BACKYARD)
            {
                if (ambienceSwitcher != null)
                {
                    ambienceSwitcher.IsBackyard = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (ambienceMode == AmbienceMode.WINDY)
            {
                if (ambienceSwitcher != null)
                {
                    ambienceSwitcher.IsWindy = false;
                }
            }
            else if (ambienceMode == AmbienceMode.BACKYARD)
            {
                if (ambienceSwitcher != null)
                {
                    ambienceSwitcher.IsBackyard = false;
                }
            }
        }
    }
}
