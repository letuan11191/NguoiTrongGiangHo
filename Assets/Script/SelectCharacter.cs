using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public static string Character;
    public Button BtnDaiDong;
    public Button BtnHaoNam;
    public Text Thongbao;
    int selected;
    Sprite imgDaiDong;
    Sprite imgTHN;    
    // Use this for initialization

    void Awake()
    {
        selected = 0;
    }

    void Start()
    {

            Character = "";
            imgDaiDong = BtnDaiDong.GetComponent<Image>().sprite;
            imgTHN = BtnHaoNam.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(selected == 1)
        {
            BtnDaiDong.GetComponent<Image>().sprite = imgDaiDong;
        }
        else if(selected == 2)
        {
            BtnHaoNam.GetComponent<Image>().sprite = imgTHN;
        }
    }

    public void clickTHN()
    {
        Character = "THN";
        BtnHaoNam.GetComponent<Image>().sprite = Resources.Load<Sprite>("THN_Select");
        selected = 1;

    }
    public void clickDaiDong()
    {
        Character = "DD";
        BtnDaiDong.GetComponent<Image>().sprite = Resources.Load<Sprite>("DaiDong_Select");
        selected = 2;

    }
    public void clickStart()
    {
        if (Character == "")
        {
            Thongbao.text = "Bạn Chưa Chọn Nhân Vật";
        }
        else
        {
            SceneManager.LoadScene("NTGH");
        }
    }
}
