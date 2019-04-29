using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manny_manager : Interactable
{
    int stage = 0;
    int lastDayGaveBabies = -1;
    bool previouslyTakedTo = false;
    int rep = 0;

    const string NAME = "Manny";

    public override void OnInteract()
    {
        if (previouslyTakedTo)
        {
            Dialog.DisplayDialog(NAME, "Hi there!");
        }
        else
        {
            Dialog.DisplayDialog("??????", "Hi there!");
        }
        stage = 1;
    }

    string[] babyLines = { "I have some children for you!", "Hungry? I brought some food from the overworld!", "I have something for you!", "I have a delivery!", "I've got some seeds!" };


    void AddBabies(int count)
    {
        for(int i = 0; i < count; i++)
        {
            GameObject.FindObjectOfType<Player_manager>().inventory.AddItemById("baby");
        }
    }

    public void GainRep(int newRep)
    {
        rep += newRep;
    }



    public void Update()
    {
        if (previouslyTakedTo)
        {
            if (stage == 1 & !Dialog.isVisible)
            {
                if (lastDayGaveBabies != GameObject.FindObjectOfType<Time_manager>().GetDay())
                {
                    Dialog.DisplayDialog(NAME, babyLines[Random.Range(0, babyLines.Length)]);
                    AddBabies((Random.Range(2, 5) * rep) + 1);
                    lastDayGaveBabies = GameObject.FindObjectOfType<Time_manager>().GetDay();


                }
                else
                {
                    Dialog.DisplayDialog(NAME, "Sorry, I don't have anymore souls today.");
                }
                stage = 0;
            }
        }
        else
        {
            if(stage == 1 & !Dialog.isVisible)
            {
                Dialog.DisplayDialog(NAME, "I am Manny, I am the reaper on this layer of hell.");
                stage = 2;
            }

            if (stage == 2 & !Dialog.isVisible)
            {
                Dialog.DisplayDialog(NAME, "Have we met before?");
                stage = 3;
            }

            if (stage == 3 & !Dialog.isVisible)
            {
                Dialog.DisplayDialog(NAME, "Oh wait! You're the Devil himself! I have some souls for you!");
                AddBabies(2);
                stage = 0;
                previouslyTakedTo = true;
            }
        }
    }
}

