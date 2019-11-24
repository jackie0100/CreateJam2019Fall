using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SoundEffect")]
public class SoundEffect : ScriptableObject
{
    public float limit; // seconds
    public bool oneShot;

    private AudioSource audioSource;
    private int selectedFile;

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

    private float timeSinceLastSound;
    private float timeLastSound;
    private float clipLength;
}
