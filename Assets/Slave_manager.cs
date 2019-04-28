using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slave_manager : Interactable
{

    string[] lines = { "Please kill me.", "I will work.", "Why can't I die?", "Life is a waste.", "Am I alive or am I dead?", "That kills..." };

    public override void OnInteract()
    {
        Dialog.DisplayDialog("Slave", lines[Random.Range(0, lines.Length)]);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
