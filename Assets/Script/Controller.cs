using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Controller : MonoBehaviour
{
    bool vaCham;
    GameObject Enemy;
    public float Speed;
    public Animator Anim;
    static float timeCombo;

    GameObject bloodEff;
    static int intCombo { get; set; }
    // Use this for initialization
    void Start()
    {
        bloodEff = GameObject.Find("Main Camera").GetComponent<Game>().BloodEff;
        vaCham = false;
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        intCombo = 1;
        timeCombo = 0;
        Speed = 10;
        Anim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Cut"))
        {
            Debug.Log("Debug Cut");
        }
    }

    void FixedUpdate()
    {
        fixPosition();
        Move();
        Fight();
        Jump();
        if (Time.time - timeCombo > 3)
        {
            intCombo = 1;
            timeCombo = Time.time;
        }
    }

    void fixPosition()
    {
        if (this.transform.position.y < 2)
        {
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {

        }

        if (this.transform.position.x < Enemy.transform.position.x)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (this.transform.position.x > Enemy.transform.position.x)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        //else if(this.transform.position.x == Enemy.transform.position.x)
        //{
        //    Enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 5);
        //}
    }

    void Move()
    {

        float translator = CrossPlatformInputManager.GetAxis("Horizontal");
        if (translator != 0)
        {
            Anim.SetTrigger("ToMove");
            this.transform.Translate(Vector3.right * translator * Speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.Z))
            {
                //Anim.ResetTrigger("ToMove");
                Anim.SetTrigger("ToMoveCut");
            }
        }
        else
        {
            Anim.ResetTrigger("ToMove");
            Anim.SetTrigger("ToIdle");
        }


    }

    void Fight()
    {
        
        if (Input.GetKeyDown(KeyCode.Z) || CrossPlatformInputManager.GetButton("Cut"))
        {
            intCombo++;
            if(vaCham)
            {
                Game.EnemyBlood -= 5;
                GameObject bloodEff_Clone = Instantiate(bloodEff, Enemy.transform.position, Quaternion.identity) as GameObject;
                bloodEff_Clone.transform.SetParent(Enemy.transform.parent);
                Destroy(bloodEff_Clone, 0.2f);
            }
            
        }

        if (Input.GetKey(KeyCode.Z) || CrossPlatformInputManager.GetButton("Cut"))
        {
            if (intCombo != 4)
            {
                Anim.SetTrigger("ToCut");
            }
            else
            {
                Anim.SetTrigger("ToMoveCut");
                intCombo = 1;
            }



        }
        if (Input.GetKeyDown(KeyCode.X) || CrossPlatformInputManager.GetButton("Kick"))
        {
            Anim.SetTrigger("ToKick");
            if (vaCham)
            {
                Debug.Log("vaCham");
                if (Game.posEnemy <= Game.posPlayer)
                {
                    Enemy.GetComponent<Rigidbody2D>().AddForce(-transform.right * 300);
                }
                else if (Game.posEnemy > Game.posPlayer)
                {
                    Enemy.GetComponent<Rigidbody2D>().AddForce(transform.right * 300);
                }
                //Instantiate(bloodEff, Enemy.transform.position, Quaternion.identity);
                Game.EnemyBlood -= 2;
            }
        }
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.X) || CrossPlatformInputManager.GetButtonUp("Cut") || CrossPlatformInputManager.GetButtonUp("Kick"))
        {
            Anim.ResetTrigger("ToCut");
            Anim.ResetTrigger("ToMove");
            Anim.ResetTrigger("ToKick");
            Anim.SetTrigger("ToIdle");
        }

    }

    void Jump()
    {

        if (this.transform.position.y < -1.79)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                //this.transform.position += new Vector3(0, 3, 0) * Time.deltaTime  * 10;
                this.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 200, 0));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.transform.tag == "Enemy")
        {
            vaCham = true;
        }
        
        //if (obj.collider.tag == "Enemy")
        //{
        //    if (Input.GetKey(KeyCode.Z))
        //    {
        //        Game.EnemyBlood -= 1/2;
        //        //obj.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(obj.transform.position.x * forceCut, obj.transform.position.y));

        //    }
        //    else if (Input.GetKey(KeyCode.X))
        //    {
        //        Game.EnemyBlood -= 3/4;
        //        //obj.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(obj.transform.position.x * forceKick, obj.transform.position.y));
        //    }
        //}
    }

    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.transform.tag == "Enemy")
        {
            vaCham = false;
        }
    }


}
