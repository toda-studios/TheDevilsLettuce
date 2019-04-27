using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricLayerer : MonoBehaviour
{

    static Transform player = null;
    int baseLayer = 0;
    SpriteRenderer render;


    private void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        render = this.GetComponent<SpriteRenderer>();
        baseLayer = render.sortingOrder;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y > transform.position.y)
        {
            render.sortingOrder = baseLayer + 1;
        }
        else
        {
            render.sortingOrder = baseLayer - 1;
        }
    }
}
