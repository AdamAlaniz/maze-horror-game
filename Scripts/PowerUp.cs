using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] public float multi = 1.3f;
    [SerializeField] public float duration = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(gameObject.CompareTag("Speed")){
                StartCoroutine(Speed(other));
            }
            if (gameObject.CompareTag("Jump"))
            {
                StartCoroutine(Jump(other));
            }
            if (gameObject.CompareTag("Health"))
            {
                Health(other);
            }
        }
            
    }

    IEnumerator Jump(Collider other)
    {
        GameObject.FindGameObjectWithTag("Jump").GetComponent<AudioSource>().Play();
        ThirdPOVPlayerController player = other.GetComponent<ThirdPOVPlayerController>();
        player.jumpIntensity *= multi;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(duration);
        player.jumpIntensity /= multi;

        Destroy(gameObject);
    }

    private void Health(Collider other)
    {
        GameObject.FindGameObjectWithTag("Health").GetComponent<AudioSource>().Play();
        ThirdPOVPlayerController player = other.GetComponent<ThirdPOVPlayerController>();
        player.health += 20;
        Destroy(gameObject);
    }

    IEnumerator Speed(Collider other)
    {
        GameObject.FindGameObjectWithTag("Speed").GetComponent<AudioSource>().Play();
        ThirdPOVPlayerController player = other.GetComponent<ThirdPOVPlayerController>();
        player.speed *= multi;
        //player.walk_speed *= multi;
        GetComponent <MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(duration);
        player.speed /= multi;

        Destroy(gameObject);
    }
   

}
