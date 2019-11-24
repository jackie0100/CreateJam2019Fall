using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxHelper : MonoBehaviour
{
    public event ContinueTextboxEvent OnTextboxContinue;

    [SerializeField]
    Text _title;
    [SerializeField]
    Text _speak;

    public static TextboxHelper Instance { get; set; }

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            OnTextboxContinue?.Invoke();
        }
    }

    public void SetText(string name, string chat)
    {
        gameObject.SetActive(true);
        _title.text = name;
        _speak.text = chat;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}

public delegate void ContinueTextboxEvent();
