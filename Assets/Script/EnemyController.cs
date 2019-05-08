using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 positionPlayer;
    Animator anim;
    GameObject player;
    GameObject bloodEff;
    bool vaCham;
    // Use this for initialization
    void Awake()
    {
        anim = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        bloodEff = GameObject.Find("Main Camera").GetComponent<Game>().BloodEff;
    }
    void Start()
    {
        vaCham = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        StartCoroutine(MoveToPlayer(5f));
    }

    void FixedUpdate()
    {
        positionPlayer = player.GetComponent<Transform>().position;
        //MoveToPlayer();
        FightToPlayer();
    }

    IEnumerator MoveToPlayer(float seconds)
    {


        yield return new WaitForSeconds(seconds);
        if (this.transform.position.x > player.GetComponent<Transform>().position.x)
        {
            anim.SetTrigger("ToMove");
            this.transform.localScale = new Vector3(-1, 1, 1);
            this.transform.Translate(Vector3.left * 2 * Time.deltaTime);
        }
        else if (this.transform.position.x < player.GetComponent<Transform>().position.x)
        {
            anim.SetTrigger("ToMove");
            this.transform.localScale = new Vector3(1, 1, 1);
            this.transform.Translate(Vector3.right * 2 * Time.deltaTime);
        }
        else
        {

        }

    }
    void FightToPlayer()
    {

    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        vaCham = true;
        if (obj.gameObject.tag == "Player")
        {
            anim.ResetTrigger("ToMove");
            int rd = Random.Range(0, 2);

            if (rd == 0)
            {
                anim.SetTrigger("ToCut");
                if (vaCham)
                {
                    Game.PlayerBlood -= 1;
                    GameObject bloodEff_Clone = Instantiate(bloodEff, player.transform.position, Quaternion.identity) as GameObject;
                    bloodEff_Clone.transform.SetParent(player.transform.parent);
                    Destroy(bloodEff_Clone, 0.2f);
                }
                //if (Game.posEnemy <= Game.posPlayer)
                //{
                //    obj.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 10);
                //}
                //else if(Game.posEnemy > Game.posPlayer)
                //{
                //    obj.gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.right * 10);
                //}

                //if (obj.transform.position.x > this.transform.position.x)
                //{
                //    //obj.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, obj.transform.position.y));

                //}
                //else
                //{
                //    obj.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, obj.transform.position.y));
                //}

            }
            else if (rd == 1)
            {
                anim.SetTrigger("ToKick");
                if (vaCham)
                {
                    Game.PlayerBlood -= 1/2;
                    if (Game.posEnemy <= Game.posPlayer)
                    {
                        player.GetComponent<Rigidbody2D>().AddForce(transform.right * 10);
                    }
                    else if (Game.posEnemy > Game.posPlayer)
                    {
                        player.GetComponent<Rigidbody2D>().AddForce(-transform.right * 10);
                    }
                }
            }



        }
    }
    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            vaCham = false;
            anim.ResetTrigger("ToCut");
            anim.SetTrigger("ToIdle");
        }
    }
}
