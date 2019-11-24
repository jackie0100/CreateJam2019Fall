using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public AudioMixerSnapshot ssDefault;
    public AudioMixerSnapshot ssSilence;

    public Animator fadeOut;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        { 
        StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        fadeOut.SetTrigger("FadeOut");
        ssSilence.TransitionTo(2f);
        yield return new WaitForSeconds(2f);
        GetComponent<AudioSource>().Stop();
        ssDefault.TransitionTo(0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
