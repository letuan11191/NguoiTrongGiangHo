using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public GameObject BloodEff;
    public GameObject BloodEff2;

    public GameObject BtnContinue;

    public GameObject Canvas_GameOver;
    public Text txtGO;

    public static float posPlayer;
    public static float posEnemy;

    public GameObject THN;
    public GameObject DaiDong;

    public GameObject THN_Clone;
    public GameObject DaiDong_Clone;

    public static int EnemyBlood;
    public static int PlayerBlood;

    public Image EnemyImageBlood;
    public Image PlayerImageBlood;

    float oldEnemyImageBlood;
    float oldPlayerImageBlood;

    void Awake()
    {
        
        Canvas_GameOver.SetActive(false);
        BtnContinue.SetActive(false);

        if(Selected.SelectedCharacter == "THN")
        {
            THN_Clone =  Instantiate(THN, new Vector3(11.22f, 1f, 0), Quaternion.identity);
            DaiDong_Clone = Instantiate(DaiDong, new Vector3(23.9f, 1f, 0), Quaternion.identity);
            THN_Clone.tag = "Player";
            DaiDong_Clone.tag = "Enemy";
            
        }
        else if (Selected.SelectedCharacter == "DD")
        {
            DaiDong_Clone = Instantiate(DaiDong, new Vector3(11.22f, 1f, 0), Quaternion.identity);
            THN_Clone = Instantiate(THN, new Vector3(23.9f, 1f, 0), Quaternion.identity);
            DaiDong_Clone.tag = "Player";
            THN_Clone.tag = "Enemy";
        }
        else
        {
            SceneManager.LoadScene("Login");
        }
    }
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        Debug.Log(EnemyImageBlood.GetComponent<RectTransform>().rect.height);
        Debug.Log(PlayerImageBlood.GetComponent<RectTransform>().rect.height);
        oldEnemyImageBlood = EnemyImageBlood.GetComponent<RectTransform>().rect.height;
        oldPlayerImageBlood = PlayerImageBlood.GetComponent<RectTransform>().rect.height;
        EnemyBlood = 200;
        PlayerBlood = 200;
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
        GameObject.FindGameObjectWithTag("Enemy").AddComponent<EnemyController>();
        GameObject.FindGameObjectWithTag("Player").AddComponent<Controller>();

    }
	
	// Update is called once per frame
	void Update () {       
        bloodCharacter();
        posPlayer = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        posEnemy = GameObject.FindGameObjectWithTag("Enemy").transform.position.x;

        if(EnemyBlood <= 0 || PlayerBlood <= 0)
        {
            Canvas_GameOver.SetActive(true);
            if(EnemyBlood <= 0)
            {
                txtGO.text = "You Win";
            }
            else
            {
                txtGO.text = "You Lose";
            }
            Time.timeScale = 0;
        }

    }

    void FixedUpdate()
    {
        checkPosition();
    }

    void bloodCharacter()
    {
        
        EnemyImageBlood.GetComponent<RectTransform>().sizeDelta = new Vector2( EnemyBlood, oldEnemyImageBlood );
        
        PlayerImageBlood.GetComponent<RectTransform>().sizeDelta = new Vector2(PlayerBlood, oldPlayerImageBlood);

    }
    void checkPosition()
    {
        if(DaiDong_Clone.transform.position.y > 1.3f)
        {
            DaiDong_Clone.transform.position = new Vector3(DaiDong_Clone.transform.position.x, 1f, 0);
        }
        if(THN_Clone.transform.position.y >1.3f)
        {
            THN_Clone.transform.position = new Vector3(THN_Clone.transform.position.x, 1f, 0);
        }
        
    }
}
