using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBall_bat_Swings : MonoBehaviour
{
    [SerializeField] private int startArc;
    [SerializeField] private int fswingArc;
    [SerializeField] private GameObject damageSphere;
    [SerializeField] private float timeBetweenAttacks = 0f;


    private void Awake()
    {
        damageSphere.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        //Update timer for time between attacks
        if(timeBetweenAttacks > 0f)
        {
            timeBetweenAttacks -= Time.deltaTime;
        }

        //Attack check if circle is triggered and take enemy life away 

        //swing bat

        if ((Input.GetKeyDown(KeyCode.Mouse0)) || Input.GetKeyDown(KeyCode.Return))
        {
            //set up for zero zero zero capture old rotation and position
            Vector3 oldpos = transform.position;
            Quaternion oldrot = transform.rotation;
            transform.position = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.Euler(fswingArc, oldrot.eulerAngles.y, oldrot.eulerAngles.z);
            transform.position = oldpos;

            // take life away of enemy inside DamageSphere
            damageSphere.SetActive(true);

        }
 
        if ((Input.GetKeyUp(KeyCode.Mouse0)) || Input.GetKeyUp(KeyCode.Return)) {
            Vector3 oldpos = transform.position;
            Quaternion oldrot = transform.rotation;
            transform.position = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.Euler(startArc, oldrot.eulerAngles.y, oldrot.eulerAngles.z);
            transform.position = oldpos;

            damageSphere.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && timeBetweenAttacks <= 0f) {
            timeBetweenAttacks = 1f;
            other.GetComponent<EnemyProperties>().takeDamage();
        }
    }



}
