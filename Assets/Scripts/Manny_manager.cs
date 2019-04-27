using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manny_manager : Interactable
{
    public override void OnInteract()
    {
        Dialog.DisplayDialog("Manny", "Hi there!");
    }
}

