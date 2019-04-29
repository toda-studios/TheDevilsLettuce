using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_startup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InventorySystem.LoadInventory();

        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);

        SceneManager.LoadScene("UI", LoadSceneMode.Additive);

        //Runs global user reporting if development build
        if (Debug.isDebugBuild)
        {
            SceneManager.LoadScene("UserReporting", LoadSceneMode.Additive);
        }
    }

}
