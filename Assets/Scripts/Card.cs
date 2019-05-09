using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Card : MonoBehaviour, ISelectHandler
{
    Ingredient _ingredient;
    public Ingredient ingredient
    {
        get { return _ingredient; }
        set
        {
            _ingredient = value;
            UpdateCard();
        }
    }

    public bool shop;
    public Image image;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Cost;

    public void OnSelect(BaseEventData eventData)
    {
        Circle.tempx = ingredient.x;
        Circle.tempy = ingredient.y;
        Circle.ingredient = ingredient;
    }

    void Start()
    {
        
    }

    void UpdateCard()
    {
        image.sprite = ingredient.sprite;
        Name.SetText(ingredient.name + (!shop ? " x" + ingredient.count : ""));

        if (shop)
        {
            Cost.SetText(ingredient.cost + " " + ingredient.currency);
        }
    }
}
