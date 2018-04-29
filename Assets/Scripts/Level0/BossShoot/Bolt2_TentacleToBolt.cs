using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt2_TentacleToBolt : MonoBehaviour {
    public Transform toBoltPos;
    public GameObject greenBolt;
    public string tentacleToBoltTrigger;

    public void CreateBolt()
    {
        Instantiate(greenBolt, toBoltPos.position, greenBolt.transform.rotation);
    }
}
