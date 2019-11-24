using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Questlist")]
public class QuestList : ScriptableObject
{
    [SerializeField]
    List<Quest> _activeQuest;

    public List<Quest> ActiveQuest
    {
        get
        {
            return _activeQuest;
        }

        set
        {
            _activeQuest = value;
        }
    }
}
