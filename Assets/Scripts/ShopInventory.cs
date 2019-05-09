using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopInventory : MonoBehaviour
{
    public TMP_InputField search;

    [SerializeField]
    Card[] cards;

    void Start()
    {
        cards = GetComponentsInChildren<Card>();

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
            if (i.name.Substring(0, search.text.Length) == search.text)
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
