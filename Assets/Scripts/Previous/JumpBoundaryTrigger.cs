using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoundaryTrigger : MonoBehaviour {
    public Transform player;
    public float y_margin_Min;
    public float y_margin_Max;

    private BoxCollider2D collider;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && CheckPlayerPosOnY())
        {
            collider.isTrigger = true;
        }
    }

    bool CheckPlayerPosOnY()
    {
        float offsetOnY = Mathf.Abs(transform.position.y - player.position.y);
        return  (offsetOnY > y_margin_Min) ? ( (offsetOnY < y_margin_Max) ? true : false) : false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            collider.isTrigger = false;
        }
    }
}
