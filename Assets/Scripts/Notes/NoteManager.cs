using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoteManager : MonoBehaviour
{
    public SearchResultNote[] searchResultNotes;
    public TMP_InputField search;

    public GameObject information;
    public TextMeshProUGUI name_text;

    public PixelLineRenderer plr;

    [SerializeField]
    NoteCircle noteCircle;

    private void Start()
    {
        searchResultNotes = GetComponentsInChildren<SearchResultNote>();

        foreach (SearchResultNote s in searchResultNotes)
        {
            s.gameObject.SetActive(false);
        }

        UpdateResults();
    }

    public void DisplayInformation(SearchResultNote p)
    {
        information.SetActive(true);

        name_text.SetText(p.ingredient.name);

        List<int> x = new List<int>();
        List<int> y = new List<int>();

        x.Add(0); x.Add(p.ingredient.notex);
        y.Add(0); y.Add(p.ingredient.notey);

        plr.DrawLines(x, y);

        noteCircle.searchResultNote = p;
    }

    public void UpdateResults()
    {
        List<Ingredient> p = new List<Ingredient>();

        for (int i = 0; i < Manager.ingredients.Count; i++)
        {
            if (Manager.ingredients[i].name.Contains(search.text) || Manager.ingredients[i].name.ToLower().Contains(search.text))
            {
                p.Add(Manager.ingredients[i]);
            }
        }

        foreach (SearchResultNote r in searchResultNotes)
        {
            r.gameObject.SetActive(false);
        }

        for (int i = 0; i < p.Count; i++)
        {
            searchResultNotes[i].gameObject.SetActive(true);
            searchResultNotes[i].name_text.SetText(p[i].name);
            searchResultNotes[i].ingredient = p[i];
        }
    }
}
