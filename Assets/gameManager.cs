using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject player;

    bool isSpawn = false;

    public void spawnPlayer()
    {
        if (isSpawn == false)
        {
            Instantiate(player);
            isSpawn = true;
        }
        
    }
}
