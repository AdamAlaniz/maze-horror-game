using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdPOVPlayerController : MonoBehaviour
{
    public float speed = 3f;
    public float hSpeed = 2.0f;
    GameObject player;
    public bool hasBat = false;
    [SerializeField] private Animator anim;
    [SerializeField] GameObject Bat;
    public bool isGrounded;
    //[SerializeField] private Slider slide;
    [SerializeField] public GameObject healthBar;
    [SerializeField] public float health = 100f;
    [SerializeField] public Text keyCount;
    [SerializeField] public Text healthNum;
    [SerializeField] public int keyNum;
    public float jumpIntensity = 5f;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!anim)
            anim = GetComponent<Animator>();
        healthNum.text = health.ToString();
        SetHealth(health);
    }

    // Update is called once per frame
    void Update()
    {

        //mouse movements
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Rotate(0, hSpeed * Input.GetAxis("Mouse X"), 0);
        transform.Translate(movement * speed * Time.deltaTime);

        //walking
        anim.SetFloat("runSpeed", Input.GetAxis("Vertical"));
        anim.SetFloat("strafeSpeed", Input.GetAxis("Horizontal"));
        
        //running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("runSpeed", Input.GetAxis("Vertical") + Input.GetAxis("Vertical"));
            anim.SetFloat("strafeSpeed", Input.GetAxis("Horizontal") + Input.GetAxis("Horizontal"));
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("jump");
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpIntensity, ForceMode.Impulse);

        }

        //swing bat
        if (hasBat && Input.GetButtonDown("Fire1"))
            anim.SetTrigger("swingBat");

        healthNum.text = health.ToString();
          
        SetHealth(health);
        //slide.value = health;
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "floor")
        {
            isGrounded = true;
        }

        if (other.gameObject.tag == "bat")
        {
            Debug.Log("touched");
            other.gameObject.SetActive(false);
            //say has bat
            hasBat = true;
            //enable bat
            Bat.SetActive(true);
            //enable animation
            anim.SetLayerWeight(anim.GetLayerIndex("NoBatMovementLayer"), 0);
            anim.SetLayerWeight(anim.GetLayerIndex("BatMovementLayer"), 1);
        }
    }

  /*  private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }*/
    public void KeyObtained()
    {
        GameObject.FindGameObjectWithTag("Key").GetComponent<AudioSource>().Play();
        keyNum++;
        keyCount.text = "Keys: " + keyNum + "/4";
    }
    public void LoseHealth()
    {
        health -= 10;
        healthNum.text = "" + health;
        SetHealth((int)health);
        if (health <= 0)
        {
            GameObject.Find("Canvas").GetComponent<GameOverMenu>().GameOverLose();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }

    public void SetMaxHealth(float h) {
        healthBar.transform.localScale = new Vector3((.9997f * (h / 100f)), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void SetHealth(float h) {
        healthBar.transform.localScale = new Vector3((.997f * (h / 100f)), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }


}
