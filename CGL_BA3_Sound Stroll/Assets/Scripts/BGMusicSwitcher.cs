using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicSwitcher : MonoBehaviour
{
    public AudioSource bgMusicOblivion;
    public AudioSource bgMusicLionsPride;
    public AudioSource bgMusicFFXIV;
    [Range(.1f,2f)]
    public float fadeInTime=1.2f;
    [Range(.1f, 1f)]
    public float maxVolume=.7f;

    public enum ActiveBGMusic
    {
        Oblivion,
        LionsPride,
        FFXIV
    }
    public ActiveBGMusic activeBGMusic;

    private void Start()
    {
        SwapBGMusic();
    }

    public void SwapBGMusic() 
    {
        StopAllCoroutines();
        StartCoroutine(FadeInBGMusic());
    }
  

    IEnumerator FadeInBGMusic()
    {
        float timwElapsed = 0f;
        if (activeBGMusic == ActiveBGMusic.Oblivion)
        {
            bgMusicOblivion.Play();

            while (timwElapsed < fadeInTime) 
            {
                bgMusicOblivion.volume = Mathf.Lerp(0f, maxVolume, fadeInTime);
                if (bgMusicLionsPride.isPlaying) 
                {
                    bgMusicLionsPride.volume = Mathf.Lerp(bgMusicLionsPride.volume, 0f, fadeInTime);
                }
                if (bgMusicFFXIV.isPlaying)
                {
                    bgMusicFFXIV.volume = Mathf.Lerp(bgMusicFFXIV.volume, 0f, fadeInTime);
                }
                timwElapsed += Time.deltaTime;
                yield return null;
            }
            bgMusicFFXIV.Stop();
            bgMusicLionsPride.Stop();

        }
        else if (activeBGMusic == ActiveBGMusic.LionsPride)
        {
            bgMusicLionsPride.Play();

            while (timwElapsed < fadeInTime)
            {
                bgMusicLionsPride.volume = Mathf.Lerp(0f, maxVolume, fadeInTime);
                if (bgMusicOblivion.isPlaying)
                {
                    bgMusicOblivion.volume = Mathf.Lerp(bgMusicOblivion.volume, 0f, fadeInTime);
                }
                if (bgMusicFFXIV.isPlaying)
                {
                    bgMusicFFXIV.volume = Mathf.Lerp(bgMusicFFXIV.volume, 0f, fadeInTime);
                }
                timwElapsed += Time.deltaTime;
                yield return null;
            }
            bgMusicFFXIV.Stop();
            bgMusicOblivion.Stop();
        }
        else if (activeBGMusic == ActiveBGMusic.FFXIV)
        {
            bgMusicFFXIV.Play();

            while (timwElapsed < fadeInTime)
            {
                bgMusicFFXIV.volume = Mathf.Lerp(0f, maxVolume, fadeInTime);
                if (bgMusicOblivion.isPlaying)
                {
                    bgMusicOblivion.volume = Mathf.Lerp(bgMusicOblivion.volume, 0f, fadeInTime);
                }
                if (bgMusicLionsPride.isPlaying)
                {
                    bgMusicLionsPride.volume = Mathf.Lerp(bgMusicLionsPride.volume, 0f, fadeInTime);
                }
                timwElapsed += Time.deltaTime;
                yield return null;
            }
            bgMusicLionsPride.Stop();
            bgMusicOblivion.Stop();
        }
    }

}
