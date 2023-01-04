using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCounting : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    private void Awake()
    {
        if (!player) {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("key obtained by player");
            player.GetComponent<ThirdPOVPlayerController>().KeyObtained();
            transform.gameObject.SetActive(false);
        }

    }

}
