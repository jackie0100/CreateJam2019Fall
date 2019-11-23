using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect: MonoBehaviour
{
    public bool oneShot;

    private AudioSource audioSource;
    private int selectedFile;

    [System.Serializable]
    public class Sound
    {
        public AudioClip soundFile;
        [Range(0.5f, 1.0f)]
        public float pitchMin;
        [Range(1.0f, 2.0f)]
        public float pitchMax;
        [Range(0f, 1f)]
        public float volume;
    }
    public Sound[] sound;

    private float timeLastSound;
    private float clipLength;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySound();
        }
    }

    public void PlaySound()
    {
        switch (oneShot)
        {
            case true:
                SetSoundSettings();
                audioSource.PlayOneShot(audioSource.clip);
                break;
            case false:
                float timeSinceLastSound = Time.fixedTime - timeLastSound;

                if (timeSinceLastSound > clipLength)
                {
                    SetSoundSettings();
                    audioSource.Play();
                    clipLength = audioSource.clip.length;
                    timeLastSound = Time.fixedTime;
                }
                break;
        }
    }

    private void SetSoundSettings()
    {
        selectedFile = Random.Range(0, sound.Length);
        audioSource.clip = sound[selectedFile].soundFile;

        float min = sound[selectedFile].pitchMin;
        if (min < 0.5f) { min = 1; }
        float max = sound[selectedFile].pitchMax;
        if (max < 0.5f) { max = min; }

        audioSource.pitch = Random.Range(min, max);
        audioSource.volume = sound[selectedFile].volume;
    }
}
