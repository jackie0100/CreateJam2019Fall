using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Quest")]
public class Quest : ScriptableObject
{
    [SerializeField]
    [TextArea]
    string _questText;
    [SerializeField]
    [TextArea]
    string _completedText;
    [SerializeField]
    int _startAtNpcId;
    [SerializeField]
    int _turninNpcId;
    [SerializeField]
    Quest[] _leadToQuest;

    public string QuestText
    {
        get
        {
            return _questText;
        }

        set
        {
            _questText = value;
        }
    }

    public string CompletedText
    {
        get
        {
            return _completedText;
        }

        set
        {
            _completedText = value;
        }
    }

    public int TurninNpcId
    {
        get
        {
            return _turninNpcId;
        }

        set
        {
            _turninNpcId = value;
        }
    }

    public Quest[] LeadToQuest
    {
        get
        {
            return _leadToQuest;
        }

        set
        {
            _leadToQuest = value;
        }
    }

    public int StartAtNpcId
    {
        get
        {
            return _startAtNpcId;
        }

        set
        {
            _startAtNpcId = value;
        }
    }
}
