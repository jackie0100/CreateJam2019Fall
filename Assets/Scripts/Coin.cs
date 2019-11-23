using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    AudioClip _coinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<AudioSource>().PlayOneShot(_coinSound);
            //collision.GetComponent<SoundEffect>().PlaySound();
            //GameObject.Find("SoundCoin").GetComponent<SoundEffect>().PlaySound();
            Destroy(this.gameObject);
        }
    }
}
