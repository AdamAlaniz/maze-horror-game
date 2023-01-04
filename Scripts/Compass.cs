using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 dir;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {

        dir.z = playerTransform.eulerAngles.y - 180f;
        transform.localEulerAngles = dir;
    }
}
