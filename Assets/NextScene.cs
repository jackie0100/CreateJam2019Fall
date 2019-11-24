using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    public Animator fadeOut;

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        fadeOut.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
