using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAutoPlay : MonoBehaviour {
    void Start()
    {
        if(GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
