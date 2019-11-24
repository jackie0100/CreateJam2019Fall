using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    [SerializeField]
    SoundEffect _soundEffectCoin;

    [SerializeField]
    AudioSource _audioSourceCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<BackPack>().Coins += 1;
            _audioSourceCoin.SetSoundSettingsAndPlayOneShot(_soundEffectCoin);
            Destroy(this.gameObject);
        }
    }
}
