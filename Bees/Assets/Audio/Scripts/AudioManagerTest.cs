using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class AudioManagerTest : MonoBehaviour
{
    // Audio Manager
    public static AudioManagerTest audioMan;

    // Array For Music Tracks
    public AudioClip[] minigameMusicTracks;
    private AudioSource audioSource;
    [SerializeField] AudioMixer masterMixer;

    // Index For Current Track
    private int currentMiniGameIndex = -1;

    void Awake()
    {
        if (audioMan == null)
        {
            audioMan = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeMusic(int minigameIndex)
    {
        if (minigameIndex != currentMiniGameIndex)
        {
            if (minigameIndex >= 0 && minigameIndex < minigameMusicTracks.Length)
            {
                currentMiniGameIndex = minigameIndex;
                audioSource.clip = minigameMusicTracks[minigameIndex];
                audioSource.Play();
            }
            else
            {
                Debug.LogError("Minigame Index Out of Range!");
            }
        }
    }
}
