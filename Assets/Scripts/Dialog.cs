using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Dialog
{
    static Dialog_manager dialog_manager;

    static bool intialized = false;

    static void Intialize()
    {
        if (!intialized)
        {
            dialog_manager = GameObject.FindObjectOfType<Dialog_manager>();

            intialized = true;
        }
    }

    public static bool isVisible
    {
        get
        {
            Intialize();
            return dialog_manager.isVisible;
        }
    }


    public static void DisplayDialog(string name, string body)
    {
        Intialize();
        dialog_manager.ShowDialogBox(name, body);
    }
}
