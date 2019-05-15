using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCircle : MonoBehaviour
{
    [SerializeField]
    NoteManager noteManager;

    public SearchResultNote searchResultNote;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if ((new Vector2(Input.mousePosition.x / Screen.width * 228 - 164, Input.mousePosition.y / Screen.height * 128 - 64)).magnitude < 60)
            {
                searchResultNote.ingredient.notex = (int)(Input.mousePosition.x / Screen.width * 228 - 164);
                searchResultNote.ingredient.notey = (int)(Input.mousePosition.y / Screen.height * 128 - 63);

                noteManager.DisplayInformation(searchResultNote);
            }
        }
    }
}
