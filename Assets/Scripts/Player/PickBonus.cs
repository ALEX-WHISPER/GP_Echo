using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBonus : MonoBehaviour {
    private PlayerMove player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bonus")
        {
            if(player.level < 5)
            {
                player.level++;
            }
            Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();
        }
        else if(other.tag == "Blue")
        {
            player.BlueSqureAdd();
            Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();
        }
        else if(other.tag == "Red")
        {
            player.RedSqureAdd();
            Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();
        }
    }
}
