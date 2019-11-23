using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideQuestNPC : MonoBehaviour
{
    [SerializeField]
    Text _questIndicator;
    [SerializeField]
    SideQuestNPC _targetTurnin;

    bool _isTurnin;

    public bool IsTurnin
    {
        get
        {
            return _isTurnin;
        }

        set
        {
            if (value)
            {
                _questIndicator.text = "?";
            }
            _isTurnin = value;

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
