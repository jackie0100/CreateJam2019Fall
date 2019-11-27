using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSoundEvent : MonoBehaviour
{
    public AudioSource audioSource;
    
    private float limit = 0.01f;
    private float timeLastSound;

    private void Start()
    {
        timeLastSound = 0;
    }

    [System.Serializable]
    public class Sound
    {
        public AudioClip soundFile;
        [Range(0.5f, 1.0f)]
        public float pitchMin = 1;
        [Range(1.0f, 2.0f)]
        public float pitchMax = 1;
        [Range(0f, 1f)]
        public float volume = 1;
    }
    public Sound[] sound;

    public void PlayCoinSound()
    {
        if (timeLastSound + limit < Time.time)
        {
           
        }
    }
}
