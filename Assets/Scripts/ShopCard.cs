using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopCard : Card
{
    public TextMeshProUGUI Cost;

    public ShopInventory shopinventory;

    public override void UpdateCard()
    {
        image.sprite = ingredient.sprite;
        Name.SetText(ingredient.name + "");
        Cost.SetText(ingredient.cost + " " + ingredient.currency);
    }

    public void SetBuyMenuCard()
    {
        shopinventory.shop_card.ingredient = ingredient;
    }

    public void AddIngredient()
    {
        ingredient.count += 1;
    }
}
