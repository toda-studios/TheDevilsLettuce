using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Descriptor_manager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition - new Vector3(-60,15);
    }

    public void SetData(string name, string type, string desc)
    {
        transform.Find("Name").GetComponent<Text>().text = name;
        transform.Find("Type").GetComponent<Text>().text = type;
        transform.Find("Desc").GetComponent<Text>().text = desc;
    }



}
