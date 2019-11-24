using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ValidLevelUpOption : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color NormalColor;
    public Color HoverColor;
    public Color ClickColor;
    public Image image;
    public GameObject levelUpPopUp;
    public GameObject Popup;
    
    [TextArea]
    public string Message;

    public void OnPointerClick(PointerEventData eventData)
    {
        image.color = ClickColor;
        levelUpPopUp.SetActive(false);    
        Popup.SetActive(true);    
        Popup.SetActive(true);    
        Popup.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = Message;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = HoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = NormalColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        NormalColor = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
