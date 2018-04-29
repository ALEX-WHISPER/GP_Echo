using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBolt1_TurnAround : MonoBehaviour, BoltMoveStraight {
    public float speed;
    public Vector2 direction;
    public string boundaryTriggerTagName;
    public Sprite spriteBack;
	// Use this for initialization
	void Start () {
        BoltMove();
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == boundaryTriggerTagName){
            ReverseScale();
            direction.y *= -1;
            GetComponent<SpriteRenderer>().sprite = spriteBack;
            BoltMove();
        }
    }

    public void BoltMove()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    private void ReverseScale()
    {
        Vector3 newScale = transform.localScale;
        newScale.y *= -1;
        transform.localScale = newScale;
    }
}
