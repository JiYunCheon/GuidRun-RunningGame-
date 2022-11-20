using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecCharacter : MonoBehaviour
{
    public Character character;

    private void OnMouseUpAsButton()
    {
        DataManager.instance.CurrentCharacter = character;
    }
}
