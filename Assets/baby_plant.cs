using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baby_plant : plant_manager
{
    public GameObject slave;

    public override void OnHarvest()
    {
        GameObject newbie = Instantiate(slave) as GameObject;
        newbie.transform.position = transform.position;
    }
}
