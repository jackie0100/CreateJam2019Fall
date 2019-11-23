using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    SoundEffect _soundEffectCoin;

    [SerializeField]
    AudioSource _audioSourceCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _audioSourceCoin.SetSoundSettingsAndPlayOneShot(_soundEffectCoin);
            //collision.GetComponent<SoundEffect>().PlaySound();
            //GameObject.Find("SoundCoin").GetComponent<SoundEffect>().PlaySound();
            Destroy(this.gameObject);
        }
    }
}
