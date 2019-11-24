using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SideQuestNPC : MonoBehaviour
{
    [SerializeField]
    int _npcId;
    [SerializeField]
    Text _questIndicator;
    [SerializeField]
    bool _hasQuest;
    [SerializeField]
    List<Quest> _quest;
    [SerializeField]
    bool _isTurnin;
    [SerializeField]
    List<SideQuestNPC> _allNpcs;
    [SerializeField]
    string _name;
    [SerializeField]
    QuestList ActiveQuest;


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
            else if (HasQuest)
            {
                _questIndicator.text = "!";
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
            else if (IsTurnin)
            {
                _questIndicator.text = "?";
            }
            else
            {
                _questIndicator.text = "";
            }
            _hasQuest = value;
        }
    }

    public List<Quest> Quest
    {
        get
        {
            return _quest;
        }

        set
        {
            _quest = value;
            if (value != null)
            {
                HasQuest = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _npcId = _allNpcs.IndexOf(this);
        HasQuest = _hasQuest;

        ActiveQuest.ActiveQuest = new List<Quest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Quest.Count > 0)
        {
            TextboxHelper.Instance.SetText(_name, Quest[0].QuestText);
            _allNpcs[Quest[0].TurninNpcId].IsTurnin = true;
            ActiveQuest.ActiveQuest.Add(Quest[0]);
            Quest.RemoveAt(0);
            Debug.Log(Quest.Count);
            if (Quest.Count == 0)
            {
                HasQuest = false;
            }
        }
        else if (collision.gameObject.tag == "Player" && ActiveQuest.ActiveQuest.Any(t => t.TurninNpcId == _npcId))
        {
            Quest activequest = ActiveQuest.ActiveQuest.First(t => t.TurninNpcId == _npcId);
            TextboxHelper.Instance.SetText(_name, activequest.CompletedText);

            foreach (Quest q in activequest.LeadToQuest)
            {
                _allNpcs[q.StartAtNpcId].HasQuest = true;
                _allNpcs[q.StartAtNpcId].Quest.Add(q);
            }

            ActiveQuest.ActiveQuest.Remove(activequest);

            if (!ActiveQuest.ActiveQuest.Any(t => t.TurninNpcId == _npcId))
            {
                IsTurnin = false;
            }

            foreach (DropsWithAmount d in activequest.Rewards)
            {
                d.ThrowItems(transform);
            }
        }
    }
}
