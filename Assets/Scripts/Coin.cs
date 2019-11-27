using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public float soundLimit; //seconds
    public static float timeLastSound;

    [SerializeField]
    SoundEvent _soundEffectCoin;

    [SerializeField]
    AudioSource _audioSourceCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BackPack.Coins += 1;
            if (timeLastSound + soundLimit + Random.value * 0.1f < Time.time)
            {
                collision.GetComponent<AudioSource>().SetSoundSettingsAndPlayOneShot(_soundEffectCoin);
                Debug.Log("play: " + Time.time);
                timeLastSound = Time.time;
            }
            Destroy(this.gameObject);
        }
    }
}
