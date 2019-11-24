using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LootUI : MonoBehaviour, IPointerClickHandler
{
    public CreateLoot Loot;
    public Text Name;
    public Image Image;
    public GameObject Popup;

    public void OnPointerClick(PointerEventData eventData)
    {        
        Popup.SetActive(true);
        Popup.SetActive(true);
        Popup.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = Loot.EquipLine;
    }

    public void Set (CreateLoot loot, GameObject popup){
        Popup = popup;
        Loot = loot;
        Name.text = loot.Name;
        Image.sprite = loot.Icon;
    }
}
