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
    public bool CloseWithInput = true;

    public static TextboxHelper Instance { get; set; }

    private void Awake()
    {
        Instance = this;

        Close();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CloseWithInput)
        {
            if (OnTextboxContinue != null)
            {
                OnTextboxContinue?.Invoke();
            }
            else
            {
                Close();
            }
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
