using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopInventory : MonoBehaviour
{
    public TMP_InputField search;

    [SerializeField]
    ShopCard[] cards;

    public ShopCard shop_card;

    void Start()
    {
        cards = GetComponentsInChildren<ShopCard>();

        foreach (ShopCard c in cards)
        {
            c.shopinventory = this;
        }

        UpdateInventory();
    }

    void Update()
    {
        
    }

    public void UpdateInventory()
    {
        List<Ingredient> ingredients = new List<Ingredient>();

        foreach (Ingredient i in Manager.ingredients)
        {
            if (i.name.Contains(search.text) || i.name.ToLower().Contains(search.text))
            {
                ingredients.Add(i);

                if (ingredients.Count >= 12)
                {
                    break;
                } 
            }
        }

        foreach (Card c in cards)
        {
            c.gameObject.SetActive(false);
        }

        for (int i = 0; i < ingredients.Count; i++)
        {
            cards[i].gameObject.SetActive(true);
            cards[i].ingredient = ingredients[i];
        }
    }
}
