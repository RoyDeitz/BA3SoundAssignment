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
            if (targetBGMusic == TargetBGMusic.Oblivion) bgMusicSwitcher.activeBGMusic = BGMusicSwitcher.ActiveBGMusic.Oblivion;
            else if (targetBGMusic == TargetBGMusic.LionsPride) bgMusicSwitcher.activeBGMusic = BGMusicSwitcher.ActiveBGMusic.LionsPride;
            else if (targetBGMusic == TargetBGMusic.FFXIV) bgMusicSwitcher.activeBGMusic = BGMusicSwitcher.ActiveBGMusic.FFXIV;

            bgMusicSwitcher.SwapBGMusic();
        }
    }


}
