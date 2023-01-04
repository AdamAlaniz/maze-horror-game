using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPlacer : MonoBehaviour
{ 
    [SerializeField] public GameObject item1;
    [SerializeField] public GameObject item2;
    [SerializeField] public GameObject item3;

   
    [SerializeField] private int NumberOfPowerUps;
    private Vector3 t;
    private Quaternion q;



    // Start is called before the first frame update
    void Awake()
    {
        
        t = new Vector3(0,0,0);
        q = Quaternion.Euler(0,0,0);
        t = new Vector3(305f, 1.5f, 305f);
        Instantiate(item1,t,q);
        Instantiate(item2, t,q);
        Instantiate(item3, t,q);
        PlacePowerUps();                           
    }

    // Update is called once per frame
    void Update()
    {

        
    }
   

    void PlacePowerUps() {
        int v = 0;
        while (v < NumberOfPowerUps)
        {
            
           
            int x = Random.Range(-148, 148);
            float y = 1.5f;
            int z = Random.Range(-148, 148);
            t = new Vector3(0, 0, 0);
            q = Quaternion.Euler(0, 0, 0);
            t = new Vector3(x, y, z);




            int i = Random.Range(1, 4);
            //Debug.Log("item"+i+" was instantiated into the game at ("+x+","+y+","+z+")");
            switch (i)
            {
                case 1:
                    {
                        GameObject itemPU = Instantiate(item1, t, q,transform);
                        break;
                    }
                case 2:
                    {
                        GameObject itemPu = Instantiate(item2, t, q,transform);
                        break;

                    }
                case 3:
                    {
                        GameObject itemPU = Instantiate(item3, t, q,transform);
                        break;
                    }
              


            }
            v++;
            if (v > NumberOfPowerUps) 
                {
                break;
                }
        }


            
    }
}
