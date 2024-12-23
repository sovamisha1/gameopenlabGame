using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipeDatabase : MonoBehaviour
{
    public List<CraftingRecipe> craftingRecipes;

    void Awake()
    {
        craftingRecipes = new List<CraftingRecipe>
        {
            new CraftingRecipe()
            {
                itemName = "Пламя возрождения",
                itemDescription = "Заебался писать UI61",
                itemSprite = Resources.Load<Sprite>("Imges/item1"),
                ingredients = new List<CraftingIngredient>
                {
                    new CraftingIngredient() { itemName = "Светлячок", quantity = 5 },
                    new CraftingIngredient()
                    {
                        itemName = "Кроваво-красный кристалл",
                        quantity = 3
                    },
                }
            },
            new CraftingRecipe()
            {
                itemName = "Сырая версия посоха",
                itemDescription = "Заебался писать UI62",
                itemSprite = Resources.Load<Sprite>("Images/item2"),
                ingredients = new List<CraftingIngredient>
                {
                    new CraftingIngredient() { itemName = "Ветвь древа жизни", quantity = 1 },
                    new CraftingIngredient() { itemName = "Капли вечной воды", quantity = 1 },
                }
            },
            new CraftingRecipe()
            {
                itemName = "Зелье Лечения",
                itemDescription = "Заебался писать UI63",
                itemSprite = Resources.Load<Sprite>("Images/item2"),
                ingredients = new List<CraftingIngredient>
                {
                    new CraftingIngredient() { itemName = "Ромашка", quantity = 3 },
                }
            },
            new CraftingRecipe()
            {
                itemName = "Тестовый крафт",
                itemDescription = "Заебался писать UI64",
                itemSprite = Resources.Load<Sprite>("Imges/item3"),
                ingredients = new List<CraftingIngredient>
                {
                    new CraftingIngredient() { itemName = "Пламя возрождения", quantity = 1 },
                    new CraftingIngredient() { itemName = "ХАХАХАХАХХААХАХ", quantity = 30 },
                }
            }
        };
    }

    public List<CraftingRecipe> GetRecipes()
    {
        return craftingRecipes;
    }
}
