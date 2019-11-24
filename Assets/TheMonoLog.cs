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
    // Start is called before the first frame update
    void Start()
    {
        
    }
    string currentSentenct;
    // Update is called once per frame
    void Update()
    {
        if (WaitUntilMono <= 0){    
            if (!PopUp.activeSelf){                
            PopUp.SetActive(true);               
            StartCoroutine("Fade"); 
            }        
        } else {
            WaitUntilMono -= Time.deltaTime;
        }
    }

    IEnumerator Fade() 
    {
        
        UpdatePopUp();
        string word = "";
        for (int i = 0; i < Monologs[0].Length; i++) 
        {
            if (Monologs[0][i] == ' '){
                currentSentenct += word + " ";
            } else {
                word += Monologs[0][i];
            }
            yield return new WaitForSeconds(.2f);
        }
        yield return null;
    }
    private void UpdatePopUp(){        
        PopUp.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = currentSentenct;
    }
}
