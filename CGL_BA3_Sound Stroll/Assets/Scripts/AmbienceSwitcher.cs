using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceSwitcher : MonoBehaviour
{
    public bool IsWindy;
    public bool IsBackyard;
    public GameObject windyAmbienceObj;
    public GameObject backwardAmbienceObj;
 

    private void Update()
    {
        if (IsWindy)
        {
            IsBackyard = false;
            //windyAmbienceObj.SetActive(true);
            if (!windyAmbienceObj.activeSelf)
            {
                 windyAmbienceObj.SetActive(true);
            }
        }
        else 
        {
            windyAmbienceObj.SetActive(false);
        }
        if (IsBackyard)
        {
            IsWindy = false;
            if (!backwardAmbienceObj.activeSelf)
            {
                backwardAmbienceObj.SetActive(true);
            }
        }
        else 
        {
            backwardAmbienceObj.SetActive(false);
        }
    }
}
