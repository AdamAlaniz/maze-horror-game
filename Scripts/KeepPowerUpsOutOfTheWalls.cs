using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPowerUpsOutOfTheWalls : MonoBehaviour
{
 
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            Destroy(this);

        }
    }
}
