using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoTransform_Bolt4 : MonoBehaviour {

    public string triggerTagName_Boundary;
    public string triggerTagName_PlayerBolt = "PlayerBolt";
    public string triggerTagName_UltimateSkill = "Ultimate";
    public GameObject afterHitBolt;
    public int scoreIncrement = 30;
    public bool ifFollowPlayer = false;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        if(ifFollowPlayer)
        {
            LookAtPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggerTagName_Boundary || other.tag == triggerTagName_PlayerBolt || other.tag == triggerTagName_UltimateSkill)
        {
            LookAtPlayer();
            Instantiate(afterHitBolt, transform.position, transform.rotation);
            GameObject.Find("UI").GetComponent<ScoreManager>().AddScore(this.scoreIncrement);
            Destroy(gameObject);
        }
    }

    void LookAtPlayer()
    {
        transform.LookAt(player);  //  绕 y 轴顺时针（自上向下俯视）旋转90度
        transform.Rotate(new Vector3(90f, 0f, 0f));     //  绕 x 轴顺时针（自前向后正视）旋转 90 度
 
        if(transform.position.x > player.position.x)
        {
            transform.Rotate(new Vector3(0f, -90f, 0f)); //  绕本地 y 轴逆时针（自右向左侧视）旋转 90 度
        }
        
        if(transform.position.x <= player.position.x)
        {
            transform.Rotate(new Vector3(0f, 90f, 0f)); //  绕本地 y 轴顺时针（自右向左侧视）旋转 90 度
        }
    }
}
