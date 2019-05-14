using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionManager : MonoBehaviour
{
    public SearchResultPotion[] searchResultPotions;
    public TMP_InputField search;

    public GameObject information;
    public Image potionimage;
    public TextMeshProUGUI name_text;
    public TextMeshProUGUI info_text;

    public Potion potion;

    private void Start()
    {
        searchResultPotions = GetComponentsInChildren<SearchResultPotion>();

        foreach (SearchResultPotion s in searchResultPotions)
        {
            s.gameObject.SetActive(false);
        }

        UpdateResults();
    }

    public void DisplayInformation(SearchResultPotion p)
    {
        information.SetActive(true);

        potionimage.sprite = Resources.Load<Sprite>("Potions/" + p.potion.type + " Potion");
        name_text.SetText(p.potion.name);
        info_text.SetText(p.potion.info);

        potion = p.potion;
    }

    public void UsePotion()
    {
        Manager.potions.Remove(potion);
    }

    public void UpdateResults()
    {
        List<Potion> p = new List<Potion>();

        for (int i = 0; i < Manager.potions.Count; i++)
        {
            if (Manager.potions[i].name.Contains(search.text) || Manager.potions[i].name.ToLower().Contains(search.text))
            {
                p.Add(Manager.potions[i]);
            }
        }

        foreach (SearchResultPotion r in searchResultPotions)
        {
            r.gameObject.SetActive(false);
        }

        for (int i = 0; i < p.Count; i++)
        {
            searchResultPotions[i].gameObject.SetActive(true);
            searchResultPotions[i].name_text.SetText(p[i].name);
            searchResultPotions[i].potion = p[i];
        }
    }
}
