using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<Music>().Length;
        if (numMusicPlayers != 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound()
    {
        sound.Play();
    }
}
