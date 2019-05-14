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

    public Image image;
    public TextMeshProUGUI Name;

    public void OnSelect(BaseEventData eventData)
    {
        Circle.ingredient = ingredient;
        Circle.selected = true;
    }

    void Start()
    {
        
    }

    public virtual void UpdateCard()
    {
        image.sprite = ingredient.sprite;
        Name.SetText(ingredient.name + " x" + ingredient.count);
    }
}
