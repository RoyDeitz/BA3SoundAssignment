using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicSwitcher : MonoBehaviour
{
    public AudioSource bgMusicOblivion;
    public AudioSource bgMusicLionsPride;
    public AudioSource bgMusicFFXIV;
    [Range(.5f,5f)]
    public float fadeInTime=2f;
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
                bgMusicOblivion.volume = Mathf.Lerp(0f, maxVolume, timwElapsed / fadeInTime);
                if (bgMusicLionsPride.isPlaying) 
                {
                    bgMusicLionsPride.volume = Mathf.Lerp(maxVolume, 0f, timwElapsed/ fadeInTime);
                }
                if (bgMusicFFXIV.isPlaying)
                {
                    bgMusicFFXIV.volume = Mathf.Lerp(maxVolume, 0f, timwElapsed / fadeInTime);
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
                bgMusicLionsPride.volume = Mathf.Lerp(0f, maxVolume, timwElapsed / fadeInTime);
                if (bgMusicOblivion.isPlaying)
                {
                    bgMusicOblivion.volume = Mathf.Lerp(maxVolume, 0f, timwElapsed / fadeInTime);
                }
                if (bgMusicFFXIV.isPlaying)
                {
                    bgMusicFFXIV.volume = Mathf.Lerp(maxVolume, 0f, timwElapsed / fadeInTime);
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
                bgMusicFFXIV.volume = Mathf.Lerp(0f, maxVolume, timwElapsed / fadeInTime);
                if (bgMusicOblivion.isPlaying)
                {
                    bgMusicOblivion.volume = Mathf.Lerp(maxVolume, 0f, timwElapsed / fadeInTime);
                }
                if (bgMusicLionsPride.isPlaying)
                {
                    bgMusicLionsPride.volume = Mathf.Lerp(maxVolume, 0f, timwElapsed / fadeInTime);
                }
                timwElapsed += Time.deltaTime;
                yield return null;
            }
            bgMusicLionsPride.Stop();
            bgMusicOblivion.Stop();
        }
    }

}
