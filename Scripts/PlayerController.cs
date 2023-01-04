using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isGrounded = true;
    [SerializeField] public float run_speed;
    [SerializeField] public float walk_speed;
    public float jumpIntensity = 5f;
    public float speed = 3f;
    public float hSpeed = 2.0f;
    GameObject player;

    [SerializeField] private Slider slide;
    [SerializeField] public float health = 100f;
    [SerializeField] public Text keyCount;
    [SerializeField] public Text healthNum;
    [SerializeField] public int keyNum;

    private void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
       
    }
    // Start is called before the first frame update
    void Start()
    {
        keyNum = 0;
        keyCount.text = "Keys: " + keyNum + "/4";
        healthNum.text = ""+health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpIntensity, ForceMode.Impulse);
        //run 
        if ((Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.RightShift)) ){ speed = run_speed; }
        else if ((Input.GetKeyUp(KeyCode.LeftShift)) || (Input.GetKeyUp(KeyCode.RightShift))) { speed = walk_speed; }

        //facing movements
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Rotate(0, hSpeed * Input.GetAxis("Mouse X"), 0);
        transform.Translate(movement * speed * Time.deltaTime);

        healthNum.text = "" + health;
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "EasyLevel"){
            Debug.Log("Easy Level Entered!");
            SceneManager.LoadScene(sceneName:"EasyMaze");
        }
           if(other.gameObject.tag == "HardLevel"){
           Debug.Log("Hard Level Entered!");
           SceneManager.LoadScene(sceneName:"HardMaze"); 
        } 
    }
    private void OnCollisionEnter(Collision collision)
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
    }
    public void KeyObtained() {
        GameObject.FindGameObjectWithTag("Key").GetComponent<AudioSource>().Play();
        keyNum++;
        keyCount.text = "Keys: " + keyNum + "/4";
    }
    public void LoseHealth()
    {
        health -= 10f;
        healthNum.text = "" + health;
        if (health <= 0)
        {
            GameObject.Find("Canvas").GetComponent<GameOverMenu>().GameOverLose();
        }
    }
 
}
