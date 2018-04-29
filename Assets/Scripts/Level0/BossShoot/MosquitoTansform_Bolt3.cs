using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoTansform_Bolt3 : MonoBehaviour
{
    public string triggerTagName;
    public GameObject tentacle_Boss2Bolt3;

    [HideInInspector]
    public bool ifChangeToTentacle = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == triggerTagName)
        {
            ifChangeToTentacle = true;
            Instantiate(tentacle_Boss2Bolt3, transform.position, tentacle_Boss2Bolt3.transform.rotation);
        }
    }
}
