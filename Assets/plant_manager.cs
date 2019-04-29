using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant_manager : Interactable
{
    public float growthTime = 360;

    public List<Sprite> growthStages;


    float timeWhenDone;
    bool doneGrowing = false;

    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        timeWhenDone = Time.time + growthTime;
    }




    // Update is called once per frame
    void Update()
    {
        if (!doneGrowing)
        {
            if (Time.time > timeWhenDone)
            {
                renderer.sprite = growthStages[growthStages.Count-1];
                doneGrowing = true;
            }
            else
            {
                renderer.sprite = growthStages[getStage()];
            }
        }
    }

    int getStage()
    {
        float percentageComplete = Mathf.Clamp((growthTime - (timeWhenDone - Time.time)) / growthTime, 0f, 1f);

        float currentStage = percentageComplete * (growthStages.Count - 1);


        return (int)currentStage;
    }




    public override void OnInteract()
    {
        if(doneGrowing)
        {
            OnHarvest();
            Destroy(this.gameObject);
        }
    }

    public virtual void OnHarvest()
    {
        Debug.Log("Harvested: " + gameObject.name);
    }





}
