using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class MiniGameMusic : MonoBehaviour
{
    public int minigameIndex;

    void Start()
    {
        AudioManagerTest.audioMan.ChangeMusic(minigameIndex);
    }

}
