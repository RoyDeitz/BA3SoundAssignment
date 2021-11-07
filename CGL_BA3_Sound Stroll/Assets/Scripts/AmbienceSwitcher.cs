using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceSwitcher : MonoBehaviour
{
    public bool IsWindy;
    public bool IsBackyard;
    public AudioSource windyAmbienceSound;
    public AudioSource backyardAmbienceSound;
    [Range(.5f,3f)]
    public float fadeInTime = .2f;

    private void Start()
    {
        IsWindy = true;
        IsBackyard = false;
        backyardAmbienceSound.Stop();
    }
    public void SwitchAmbience() 
    {
        StopAllCoroutines();
        StartCoroutine(FadeInAmbience());
    }


 
    IEnumerator FadeInAmbience()
    {
        float timwElapsed = 0f;
        if (IsWindy)
        {
            windyAmbienceSound.Play();

            while (timwElapsed < fadeInTime)
            {
                windyAmbienceSound.volume = Mathf.Lerp(0f, 1, timwElapsed / fadeInTime);
                if (backyardAmbienceSound.isPlaying)
                {
                    backyardAmbienceSound.volume = Mathf.Lerp(1f, 0f, timwElapsed / fadeInTime);
                }

                timwElapsed += Time.deltaTime;
                yield return null;
            }
            backyardAmbienceSound.Stop();

        }
        else if (IsBackyard)
        {
            backyardAmbienceSound.Play();

            while (timwElapsed < fadeInTime)
            {
                windyAmbienceSound.volume = Mathf.Lerp(0f, 1, timwElapsed / fadeInTime);
                if (windyAmbienceSound.isPlaying)
                {
                    windyAmbienceSound.volume = Mathf.Lerp(1f, 0f, timwElapsed / fadeInTime);
                }

                timwElapsed += Time.deltaTime;
                yield return null;
            }
            windyAmbienceSound.Stop();

        }
        else 
        {
            while (timwElapsed < fadeInTime)
            {
                if (backyardAmbienceSound.isPlaying)
                {
                    backyardAmbienceSound.volume = Mathf.Lerp(1f, 0f, timwElapsed / fadeInTime);
                }
                else if (windyAmbienceSound.isPlaying)
                {
                    windyAmbienceSound.volume = Mathf.Lerp(1f, 0f, timwElapsed / fadeInTime);
                }

                timwElapsed += Time.deltaTime;
                yield return null;
            }
            windyAmbienceSound.Stop();
            backyardAmbienceSound.Stop();
        }
    }
}
