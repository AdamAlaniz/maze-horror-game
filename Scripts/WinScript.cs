using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPOVPlayerController>().keyNum == 4)
        {
            GameObject.Find("Canvas").GetComponent<GameOverMenu>().GameOverWin();
        }
    }
}
