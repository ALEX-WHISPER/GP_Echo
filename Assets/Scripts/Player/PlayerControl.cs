using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float force_Value;	    //  行进时给角色施加的物理力
    public float jump_ForceVaule;	//  跳跃时施加的物理力

    //行进间的速度范围控制
    public float max_speed;
    public float min_speed;

    //跳起时的速度范围控制
    public float up_MaxSpeed;
    public float up_MinSpeed;

    public bool isFaceRight;	    //  是否面向右边

    public GameObject groundCheck;

    private bool whether_Jump;		//  是否可以起跳
    private bool if_OnGround;		//  是否与地面层接触

    private Rigidbody2D hero;

    void Start()
    {
        whether_Jump = false;
        if_OnGround = false;
        hero = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 start = transform.position;
        Vector3 end = groundCheck.transform.position;

        if_OnGround = Physics2D.Linecast(start, end, 1 << LayerMask.NameToLayer("Ground"));
    }

    void FixedUpdate()
    {
        float x_Move = Input.GetAxis("Horizontal");
        float y_Move = Input.GetAxis("Vertical");

        //  Walk
        if (x_Move != 0) 	//  只要左右发生移动
        {
            Vector2 MoveForce_X = Vector2.right * x_Move * force_Value;	//  对角色向对应方向施加物理力
            hero.AddForce(MoveForce_X);

            //控制角色的水平速度再某一范围内
            hero.velocity = new Vector2(Mathf.Clamp(hero.velocity.x, x_Move * min_speed, x_Move * max_speed), hero.velocity.y);
        }

        if (y_Move != 0)
        {
            Vector2 MoveForce_Y = Vector2.up * y_Move * force_Value;	//  对角色向对应方向施加物理力
            hero.AddForce(MoveForce_Y);

            //  控制角色的水平速度再某一范围内
            hero.velocity = new Vector2(hero.velocity.x, Mathf.Clamp(hero.velocity.y, y_Move * min_speed, y_Move * max_speed));
        }
        //  Walk

        //Flip
        if (x_Move > 0 && !isFaceRight) 	//朝右走但面向左边
        {
            flip();	//转身
        }

        if (x_Move < 0 && isFaceRight)		//朝左走但面向右边 
        {
            flip();		//转身
        }
        //Flip

        //Jump
        if (Input.GetKey(KeyCode.Space) && (if_OnGround))		//按下方向键“up”，且最少满足此三个变量其中一个为真，即可起跳
        {
            whether_Jump = true;
        }

        if (whether_Jump)
        {
            Vector2 jumpForce = Vector2.up * jump_ForceVaule;	//施加向上的力
            hero.AddForce(jumpForce);

            //控制垂直方向上的速度再某一范围内
            hero.velocity = new Vector2(hero.velocity.x, Mathf.Clamp(hero.velocity.y, up_MinSpeed, up_MaxSpeed));
            whether_Jump = false;
        }
        //Jump
    }

    //转身函数
    void flip()
    {
        isFaceRight = !isFaceRight;
        Vector3 NewScale = transform.localScale;
        NewScale.x *= -1;
        transform.localScale = NewScale;
    }
}
