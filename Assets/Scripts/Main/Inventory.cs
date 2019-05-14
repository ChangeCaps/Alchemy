using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    Card[] cards;

    private void Start()
    {
        cards = GetComponentsInChildren<Card>();

        UpdateInventory();
    }

    public void UpdateInventory()
    {
        foreach (Card c in cards)
        {
            c.gameObject.SetActive(false);
        }

        for (int i = 0; i < Manager.ingredients.Count; i++)
        {
            if (Manager.ingredients[i].count > 0)
            {
                cards[i].gameObject.SetActive(true);
                cards[i].ingredient = Manager.ingredients[i];
            }
        }
    }
}
