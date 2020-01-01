using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks; //Serialized for debugging
    SceneLoader sceneLoader;


    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    void Update()
    {
      if (breakableBlocks < 1)
        {
            sceneLoader.LoadNextScene();
        }
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }
    public void RemoveBreakableBlock()
    {
        breakableBlocks--;
    }
}
