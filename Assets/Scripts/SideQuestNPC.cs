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
    [SerializeField]
    bool _hasQuest;
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
            else
            {
                _questIndicator.text = "";
            }
            _isTurnin = value;

        }
    }

    public bool HasQuest
    {
        get
        {
            return _hasQuest;
        }

        set
        {
            if (value)
            {
                _questIndicator.text = "!";
            }
            else
            {
                _questIndicator.text = "";
            }
            _hasQuest = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        HasQuest = _hasQuest;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && _hasQuest)
        {
            _targetTurnin.IsTurnin = true;
            HasQuest = false;
        }
        if (collision.gameObject.tag == "Player" && _isTurnin)
        {
            IsTurnin = false;
            HasQuest = true;
            GetComponent<ThrowCoins>().ThrowSomeCoins();
        }
    }
}
