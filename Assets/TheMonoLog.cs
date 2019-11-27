using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheMonoLog : MonoBehaviour
{
    
    [TextArea]
    public List<string> Monologs;
    [TextArea]
    public List<string> Winolog;
    public GameObject PopUp;
    public float WaitUntilMono;
    public bool isTalking = false;
    public int CurrentMono = 0;
    public bool hasWon = false;
    public GameObject WinText;
    
    // Start is called before the first frame update

    private AudioSource audioSource;
    public AudioClip [] monologAudio;

    public SoundEvent deathSound;
    public AudioSource bossSoundSource;

    public SoundEvent victoryMusic;
    public AudioSource victoryMusicSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    string currentSentenct;
    // Update is called once per frame
    void Update()
    {
    
        if (WaitUntilMono <= 0){    
            if (!PopUp.activeSelf){                
            PopUp.SetActive(true);      
            if ((!isTalking && CurrentMono < Monologs.Count) && !hasWon){
                isTalking = true;
                
                StartCoroutine("Fade"); 
            }         
            }        
        } else {
            WaitUntilMono -= Time.deltaTime;
        }
    }
    public void win () {        
        if (!hasWon){
            hasWon = true;
            StopAllCoroutines();
            CurrentMono = 0;
            isTalking = true;
            StartCoroutine("FadeWin"); 
        }
    }
    IEnumerator Fade() 
    {
        audioSource.clip = monologAudio[CurrentMono];
        
        UpdatePopUp();
        print("Called");
        string word = "";
        for (int i = 0; i < Monologs[CurrentMono].Length; i++) 
        {
            if (Monologs[CurrentMono][i] == ' '){
                currentSentenct += word + " ";
                word = "";                
                UpdatePopUp();
                audioSource.mute = true;
                yield return new WaitForSeconds(.01f);
                audioSource.mute = false;
                audioSource.Play();
            } else {
                word += Monologs[CurrentMono][i];
                
            }
            yield return new WaitForSeconds(.05f);
        }
        currentSentenct += word;       
        UpdatePopUp();
        isTalking = false;
        CurrentMono += 1;
        
        yield return new WaitForSeconds(.5f);
        currentSentenct = "";
        StopCoroutine(Fade());
    }

    IEnumerator FadeWin() 
    {
        bossSoundSource.SetSoundSettingsAndPlayOneShot(deathSound);
        victoryMusicSource.Stop();
        victoryMusicSource.SetSoundSettingsAndPlayOneShot(victoryMusic);

        currentSentenct = "";
        UpdatePopUp();
        print("Won");
        string word = "";
        for (int i = 0; i < Winolog[CurrentMono].Length; i++) 
        {
            if (Winolog[CurrentMono][i] == ' '){
                currentSentenct += word + " ";
                word = "";                
                UpdatePopUp();
            } else {
                word += Winolog[CurrentMono][i];
            }
            yield return new WaitForSeconds(.05f);
        }
        currentSentenct += word;       
        UpdatePopUp();
        isTalking = false;
        CurrentMono += 1;
        
        yield return new WaitForSeconds(.5f);
        WinText.SetActive(true);
        StopCoroutine(FadeWin());
    }

    private void UpdatePopUp(){        
        PopUp.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentSentenct;
    }
}
