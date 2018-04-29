using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {
    public List<string> exceptionTags;
    void OnTriggerExit2D(Collider2D other)
    {
        if(!exceptionTags.Contains(other.tag))
        {
            DestroyObject(other.gameObject);
        }
    }
}
