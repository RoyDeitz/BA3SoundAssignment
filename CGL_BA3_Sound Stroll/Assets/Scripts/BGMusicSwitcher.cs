using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicSwitcher : MonoBehaviour
{
    public AudioSource bgMusicOblivion;
    public AudioSource bgMusicLionsPride;
    public AudioSource bgMusicFFXIV;
    [Range(.01f, .1f)]
    public float increaseBy=.1f;
    [Range(.01f, .1f)]
    public float decreaseBy=.1f;
    [Range(.01f, .1f)]
    public float smoothingTime=.1f;
    [Range(.1f, 1f)]
    public float maxVolume=.8f;

    public enum ActiveBGMusic
    {
        Oblivion,
        LionsPride,
        FFXIV
    }
    public ActiveBGMusic activeBGMusic;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FadeOutOtherBGMusic()
    {
        if (activeBGMusic == ActiveBGMusic.Oblivion)
        {
            StartCoroutine(FadeOutThisMusic(bgMusicFFXIV));
            StartCoroutine(FadeOutThisMusic(bgMusicLionsPride));

        }
        else if (activeBGMusic == ActiveBGMusic.LionsPride)
        {
            StartCoroutine(FadeOutThisMusic(bgMusicFFXIV));
            StartCoroutine(FadeOutThisMusic(bgMusicOblivion));
        }
        else if (activeBGMusic == ActiveBGMusic.FFXIV)
        {
            StartCoroutine(FadeOutThisMusic(bgMusicLionsPride));
            StartCoroutine(FadeOutThisMusic(bgMusicOblivion));
        }
    }

    IEnumerator FadeOutThisMusic(AudioSource audioSource)
    {
        while (audioSource.volume != 0)
        {
            float tempVol = bgMusicFFXIV.volume;
            tempVol -= decreaseBy;
            if (tempVol <= 0)
            {
                audioSource.volume = 0;
            }
            else
            {
                audioSource.volume = tempVol;
            }
            yield return new WaitForSeconds(smoothingTime);
        }

    }

    IEnumerator FadeInThisMusic(AudioSource audioSource)
    {
        while (audioSource.volume != .8)
        {
            float tempVol = bgMusicFFXIV.volume;
            tempVol -= decreaseBy;
            if (tempVol <= 0)
            {
                audioSource.volume = 0;
            }
            else
            {
                audioSource.volume = tempVol;
            }
            yield return new WaitForSeconds(smoothingTime);
        }

    }
}
