using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CraftingRecipe
{
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
    public List<CraftingIngredient> ingredients;
}
