using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    [SerializeField] private Transform player_Transform;
    [SerializeField] private GameObject player;
    [SerializeField] private float playerDistance;
    [SerializeField] private float awareAI = 10f;
    [SerializeField] private float AIMoveSpeed;
    [SerializeField] private Animator anim;

    [SerializeField] private Transform[] waypoints;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private int currWaypoint = 0;
    [SerializeField] Transform goal;
    [SerializeField] private float attackTimer = 0f;
    public bool dead = false;


    // Start is called before the first frame update

    void Start()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (!anim)
            anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");
        player_Transform = player.transform;
        goal = player_Transform;
       
        agent.destination = goal.position;
        agent.autoBraking = false;
        AIMoveSpeed = GetComponent<EnemyProperties>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }

        playerDistance = Vector3.Distance(player_Transform.position, transform.position);
        if (playerDistance < awareAI)
        {
            LookAtPlayer();
            //Debug.Log("Player Found");

            if (playerDistance > 2f)
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
                Chase();

                if(playerDistance < 3f)
                {
                    anim.SetTrigger("Attack");
                    if (attackTimer <= 0f)
                        attack();
                }
            }
            else
            {
                GoToNextPoint();
            }
        }
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        AIMoveSpeed = GetComponent<EnemyProperties>().speed;
        if (agent.remainingDistance < 0.5f)
            GoToNextPoint();
    }
    void LookAtPlayer()
    {
        transform.LookAt(player_Transform);
    }



    private void GoToNextPoint()
    {
        if (waypoints.Length == 0)
            return;
        agent.destination = waypoints[currWaypoint].position;
        currWaypoint = (currWaypoint + 1) % waypoints.Length;
    }

    private void Chase()
    {
        transform.Translate(Vector3.forward * AIMoveSpeed * Time.deltaTime);
    }

    private void attack()
    {
        AIMoveSpeed = 0;
        attackTimer = 5f;
        player.GetComponent<ThirdPOVPlayerController>().LoseHealth();
    }
}
