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
                    ambienceSwitcher.SwitchAmbience();
                }
            }
            else if (ambienceMode == AmbienceMode.BACKYARD)
            {
                if (ambienceSwitcher != null)
                {
                    ambienceSwitcher.IsBackyard = true;
                    ambienceSwitcher.SwitchAmbience();
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
                    ambienceSwitcher.SwitchAmbience();
                }
            }
            else if (ambienceMode == AmbienceMode.BACKYARD)
            {
                if (ambienceSwitcher != null)
                {
                    ambienceSwitcher.IsBackyard = false;
                    ambienceSwitcher.SwitchAmbience();
                }
            }
        }
    }
}
