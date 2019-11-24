using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpPopUp : MonoBehaviour
{
    private Vector3 startPosistion;
    public  Vector3 MovePosistion;
    public Vector3 EndPosistion;
    public  float TimeSpan;
    public int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        startPosistion = transform.position;
        transform.position += 4000 * Vector3.down;
    }
    public void LevelUp (){
        transform.position = startPosistion;
    }

    public void Close ()
    {
        transform.position += 4000 * Vector3.down;
    }
    // Update is called once per frame
    void Update()
    {/*
        print (state);
        if (state == 1){
            transform.position = Vector3.MoveTowards(transform.position, startPosistion, 5);
        } else if (state == 2){            
            transform.position = Vector3.MoveTowards(transform.position, EndPosistion + startPosistion, TimeSpan);
        }
    */
    }
}
