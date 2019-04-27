using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_manager : MonoBehaviour
{
    bool ignoreNextPress = false;

    public bool isVisible
    {
        get
        {
            return transform.GetChild(0).gameObject.activeInHierarchy;
        }
    }

    string dialogName
    {
        get
        {
            return transform.GetChild(0).Find("Name").GetComponent<Text>().text;
        }
        set
        {
            transform.GetChild(0).Find("Name").GetComponent<Text>().text = value;
        }
    }

    string dialogBody
    {
        get
        {
            return transform.GetChild(0).Find("Body").GetComponent<Text>().text;
        }
        set
        {
            transform.GetChild(0).Find("Body").GetComponent<Text>().text = value;
        }
    }

    public void ShowDialogBox(string name, string body)
    {
        dialogName = name;
        dialogBody = body;
        this.transform.GetChild(0).gameObject.SetActive(true);
        ignoreNextPress = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (isVisible & !ignoreNextPress)
            {
                this.transform.GetChild(0).gameObject.SetActive(false);
            }
            ignoreNextPress = false;
        }
        
    }
}
