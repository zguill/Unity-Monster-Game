using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MonsterScript : MonoBehaviour {

    public static MonsterScript instance;

    [SerializeField]
    private Rigidbody2D myRigidBody;

    [SerializeField]
    private Animator anim; 

    private float forwardSpeed=3f;

    private float bounceSpeed=4f;

    private bool didFly;

    public bool isAlive;

    public int score;

     

    void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
        isAlive = true;
        score = 0; 

        SetCamerasX(); 

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (isAlive)
        {
            Vector3 temp = transform.position;
            temp.x += forwardSpeed * Time.deltaTime;
            transform.position = temp;

            if (didFly)
            {
                didFly = false;
                myRigidBody.velocity = new Vector2(0, bounceSpeed);
                anim.SetTrigger("Fly");

            }

            if(myRigidBody.velocity.y>= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0)
;
            }
            else
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -myRigidBody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
	}

    void SetCamerasX()
    {
        CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f; 
    }

    public float GetPositionX()
    {
        return transform.position.x; 
    }

    public void FlyTheMonster()
    {
        didFly = true; 
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag=="Ground"|| target.gameObject.tag == "Lazer")
        {
            if (isAlive)
            {
                isAlive = false;
                anim.SetTrigger("Monster Died");
                GameController.instance.MonsterDied(); 
            }
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "LazerHolder")
        {
            
            score++; 
        }
    }
}
