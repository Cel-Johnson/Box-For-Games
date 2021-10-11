using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int blocksRemaining;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
       
        {
            blocksRemaining++;
        }
    }
 public void BlockDestroyed()
    {
        blocksRemaining--;
        if (blocksRemaining <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
                                                                           