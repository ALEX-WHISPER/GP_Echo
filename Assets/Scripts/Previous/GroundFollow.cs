using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFollow : MonoBehaviour {
    public PlayerControl playerCtrl;
    public Transform player;
    public float offsetOnY;

    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position = new Vector3(transform.position.x, player.position.y + offsetOnY, 0f);
        }
    }
}
