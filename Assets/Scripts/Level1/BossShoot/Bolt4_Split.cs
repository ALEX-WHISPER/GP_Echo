using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt4_Split : MonoBehaviour {
    public GameObject subBolt;
    public int shotCount;
    public int boltCount;
    public float moveSpeed;
    public float boltDelay;
    public float destroyDelay;

    private bool ifMove = true;
    private float randomRotation;
    private Quaternion offsetQuaternion;
	// Use this for initialization
	void Start () {
        randomRotation = Random.Range(-180f, 180f);
        offsetQuaternion = Quaternion.Euler(new Vector3(0f, 0f, randomRotation));
	}
	
	// Update is called once per frame
	void Update () {

		if(!ifMove)
        {
            return;
        }

        transform.Translate(Vector3.right * -1 * moveSpeed * Time.deltaTime, Space.Self);
	}

    IEnumerator Split()
    {
        Quaternion instanceRotation = offsetQuaternion;
        for (int j = 0; j < boltCount; j++)
        {
            for (int i = 0; i < shotCount; i++)
            {
                Instantiate(subBolt, transform.position, instanceRotation);
                //instanceRotation = Quaternion.Euler(new Vector3(0f, 0f, 60 * (i + 1)));
                instanceRotation.eulerAngles = new Vector3(0f, 0f, instanceRotation.eulerAngles.z + 60);
            }
            yield return new WaitForSeconds(boltDelay);
        }
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SplitTrigger")
        {
            ifMove = false;

            if (GetComponent<SpriteRenderer>().sprite != null)
                GetComponent<SpriteRenderer>().sprite = null;

            StartCoroutine(Split());
        }
    }
}
