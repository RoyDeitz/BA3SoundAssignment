using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicTrigger : MonoBehaviour
{
    BGMusicSwitcher bgMusicSwitcher;
    public enum TargetBGMusic 
    {
        Oblivion,
        LionsPride,
        FFXIV
    }
    public TargetBGMusic targetBGMusic;
    void Start()
    {
        bgMusicSwitcher = FindObjectOfType<BGMusicSwitcher>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            if (targetBGMusic == TargetBGMusic.Oblivion)
            {
                if (bgMusicSwitcher.activeBGMusic != BGMusicSwitcher.ActiveBGMusic.Oblivion)
                {
                    bgMusicSwitcher.activeBGMusic = BGMusicSwitcher.ActiveBGMusic.Oblivion;
                    bgMusicSwitcher.SwapBGMusic();
                }
            }
            else if (targetBGMusic == TargetBGMusic.LionsPride)
            {
                if (bgMusicSwitcher.activeBGMusic != BGMusicSwitcher.ActiveBGMusic.LionsPride)
                {
                    bgMusicSwitcher.activeBGMusic = BGMusicSwitcher.ActiveBGMusic.LionsPride;
                    bgMusicSwitcher.SwapBGMusic();
                }
            }
            else if (targetBGMusic == TargetBGMusic.FFXIV)
            {
                if (bgMusicSwitcher.activeBGMusic != BGMusicSwitcher.ActiveBGMusic.Oblivion)
                {
                    bgMusicSwitcher.activeBGMusic = BGMusicSwitcher.ActiveBGMusic.FFXIV;
                    bgMusicSwitcher.SwapBGMusic();
                }
            }
           
        }
    }


}
