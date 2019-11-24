using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "NewLoot", menuName = "Loot")]
public class CreateLoot : ScriptableObject {
	public string Name;
    [TextArea]
    public string EquipLine;
    [TextArea]
    public string SellLine;
    public Sprite Icon;
}
