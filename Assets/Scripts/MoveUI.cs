using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUI : MonoBehaviour
{
    private Vector3 startPosistion;
    public  Vector3 MovePosistion;
    public  float TimeSpan;
    // Start is called before the first frame update
    void Start()
    {
        startPosistion = transform.position;
        transform.position += MovePosistion;
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = Vector3.MoveTowards(transform.position, startPosistion, TimeSpan);
    }
}
