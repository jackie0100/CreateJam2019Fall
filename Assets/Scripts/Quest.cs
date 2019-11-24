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
    [SerializeField]
    DropsWithAmount[] _rewards;

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

    public DropsWithAmount[] Rewards
    {
        get
        {
            return _rewards;
        }

        set
        {
            _rewards = value;
        }
    }
}

[System.Serializable]
public class DropsWithAmount
{
    [SerializeField]
    int _amount;
    [SerializeField]
    GameObject _dropPrefab;

    public int Amount
    {
        get
        {
            return _amount;
        }
        set
        {
            _amount = value;
        }
    }

    public GameObject DropPrefab
    {
        get
        {
            return _dropPrefab;
        }
        set
        {
            _dropPrefab = value;
        }
    }

    public void ThrowItems(Transform target)
    {
        for (int i = 0; i < _amount; i++)
            GameObject.Instantiate(_dropPrefab, target.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f)), Quaternion.identity);
    }
}
