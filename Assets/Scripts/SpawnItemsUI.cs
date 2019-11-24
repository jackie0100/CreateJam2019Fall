using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnItemsUI : MonoBehaviour
{
    public int NumberOfLoot = 10;
    public float Hight;
    public GameObject ItemUi;
    public GameObject Player;

    public GameObject PopUp;
    private BackPack backPack;
    private List<GameObject> children = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable() {
        if (Player ==null) {
            Player = FindObjectOfType<PlayerControls>().gameObject;
        }
        backPack = Player.GetComponent<BackPack>();
        NumberOfLoot = backPack.Loots.Count;
        for (int i = 0; i < NumberOfLoot; i++){
            SpawnItem (i);
        }
        if (NumberOfLoot > 3){
            RectTransform transform = GetComponent<RectTransform>();
            transform.sizeDelta = new Vector2(transform.sizeDelta.x, transform.sizeDelta.x + (NumberOfLoot - 3) * Hight);                                   
        }
    }
    void OnDisable()
    {
        foreach (GameObject child in children){
            Destroy(child);
        }
    }
    
    private void SpawnItem (int number) {
        GameObject item = Instantiate(ItemUi);
        children.Add(item);
        item.transform.SetParent(this.gameObject.transform);
        RectTransform transform = item.GetComponent<RectTransform>();
        LootUI script = item.GetComponent<LootUI>();
        script.Set(backPack.Loots[number], PopUp);
        transform.localPosition = new Vector3 (0, -Hight * number, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
