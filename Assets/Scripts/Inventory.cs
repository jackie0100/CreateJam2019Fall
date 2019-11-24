using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Inventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color Hover; 
    public Color Pressed; 
    public GameObject ToOpen;
    Color Normal;
    Image image;

    public void OnPointerClick(PointerEventData eventData)
    {
        image.color = Pressed;
        if (ToOpen.activeSelf){
            ToOpen.SetActive(false);
        } else {
            ToOpen.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Hover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Normal;
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        Normal = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
