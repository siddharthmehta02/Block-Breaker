using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks; // Serialize just for debugging

    public SceneLoader sceneloader;



    public void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }
    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void blockDestoyed()
    {
        breakableBlocks--;
        if(breakableBlocks<=0)
        {
            
            sceneloader.LoadNextScene();

        }
    }

}
