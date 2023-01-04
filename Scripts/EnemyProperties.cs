using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public GameObject healthBar;
    public float speed;
    [SerializeField] private int strength;
    [SerializeField] private Animator anim;

    private void Start()
    {
        //Check for easy mode
        if(PlayerPrefs.GetInt("Difficulty") == 0)
        {
            health = 100;
            strength = 10;
        }
        //Check for hard mode
        else if(PlayerPrefs.GetInt("Difficulty") == 1)
        {
            health = 150;
            strength = 30;
        }
    }

    public void takeDamage()
    {
        health -= strength;
        healthBar.transform.localScale = new Vector3((health / 50f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        if (health <= 0)
        {
            GetComponent<enemyController>().dead = true;
            Destroy(gameObject, 5f);
        }
    }
}
