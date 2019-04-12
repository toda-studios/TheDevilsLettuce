using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_startup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Runs global user reporting if development build
        if (Debug.isDebugBuild)
        {
            SceneManager.LoadScene("UserReporting", LoadSceneMode.Additive);
        }
    }

}
