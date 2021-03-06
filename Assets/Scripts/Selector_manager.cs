using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Selector_manager : MonoBehaviour
{
    List<Collider2D> collisions = new List<Collider2D>(); 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interactable>() != null)
        {
            collisions.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collisions.Contains(collision))
        {
            collisions.Remove(collision);
        }
    }

    public Interactable GetInterable()
    {
        if(collisions.Count > 0)
        {
            return collisions[0].GetComponent<Interactable>();
        }
        return null;
    }

    public bool isPlantable()
    {
        foreach(Collider2D col in collisions)
        {
            if(col.name == "Plots")
            {
                return true;
            }
        }
        return false;
    }

    public Interactable getPlant()
    {
        foreach (Collider2D col in collisions)
        {
            if (col.GetComponent<plant_manager>() != null)
            {
                return col.GetComponent<Interactable>();
            }
        }
        return null;
    }

}
