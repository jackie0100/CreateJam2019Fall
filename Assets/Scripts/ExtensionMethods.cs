using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static void SetSoundSettingsAndPlayOneShot(this AudioSource audioSource, SoundEffect targetaudio)
    {
        int selectedFile = Random.Range(0, targetaudio.sound.Length);

        audioSource.pitch = Random.Range(targetaudio.sound[selectedFile].pitchMin, targetaudio.sound[selectedFile].pitchMax);
        audioSource.volume = targetaudio.sound[selectedFile].volume;
        audioSource.PlayOneShot(targetaudio.sound[selectedFile].soundFile);
    }
}
