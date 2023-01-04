using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAnimeController : MonoBehaviour
{

// TODO: Connect animations to script

    [SerializeField] private Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        if(!anime)
            anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anime.SetFloat("WalkSpeed", Input.GetAxis("Vertical"));
    }
}
