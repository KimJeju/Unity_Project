using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;                  //BigInteger를 사용하기 위해서 선언
using System.Numerics;         // Numerics 네임스페이스를 선언해야 BigInterger를 사용할 수 있다. 닷넷에 포함된 기본숫자형에 새로운 숫자형 포함
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public class Player_Value
    {
        public BigInteger Gold; // 전투 후 갖게되는 골드량
        public BigInteger Level_Hp; // 레벨업 후 올라가는 체력량
        public BigInteger Level_Damege; // 레벨업 후 올라가는 데미지

        public string States;


        public void Get_Gold(BigInteger Value, UnityEngine.Vector3 pos) //골드를 받기 위한 메서드, 1이 아닌 특정한 값을 받기위해 Biginteger Value를 받게 해준다.
        {
            Gold += Value;
            GameManager.Instance.Text_Gold.text = "Gold : " + Gold;
            GameManager.Instance.Set_Text(Value.ToString(), pos);

        }

        public void Get_LevelHp() //레벨을 올리기 위한 메서드
        {
            if (Gold >= Level_Hp * 10)
            {
                Gold -= Level_Hp * 10;
                Level_Hp += 1;
                
                States = "hp";
                Player.Instance.LevelUp(States);
                GameManager.Instance.Text_level_Hp.text = "Level HP : " + Level_Hp;
                GameManager.Instance.Text_Gold.text = "Gold :" + Gold;

            }else{
                GameManager.Instance.Set_Text("HP 레벨업을 위한 골드가 모자랍니다.");
            }
        }
        public void Get_LevelDamege() //데미지를 올리기 위한 메서드
        {

            if (Gold >= Level_Damege * 5)
            {
                Gold -= Level_Damege * 5;
                Level_Damege += 1;
                GameManager.Instance.Text_level_Damege.text = "Level Damege : " + Level_Damege;

                States = "Damege";
                Player.Instance.LevelUp(States);
                GameManager.Instance.Text_level_Hp.text = "Level Damege : " + Level_Damege;
                GameManager.Instance.Text_Gold.text = "Gold :" + Gold;
            }else{
                GameManager.Instance.Set_Text("데미지 레벨업을 위한 골드가 모자랍니다.");
            }


        }
    }

    public static GameManager Instance; //게임매니저를 자료형으로 가지는 인스턴스 선언, Static 메서드로 정적으로 선언
    public Text Text_Gold;
    public Text Text_level_Hp;
    public Text Text_level_Damege;
    public Player_Value m_Player_Value;

    public Text Text_Damege; //데미지를 위한 텍스트
    public List<Text> Text_List; //텍스트 데미지를 풀링하기 위한 리스트, 다시 생성되었던 리스트를 재활용하기위한 리스트

    private void Awake() //첫번째 프레임이 호출되기전에 딱 한번 호출되는 유니티 내장함수, 모든상태와 게임을 초기화 해주기 위해 선언
    {
        Instance = this; //this는 게임매니저의 인스턴스
    }
    //GameManager.instance

    // Start is called before the first frame update
    void Start()
    {
        m_Player_Value = new Player_Value(); //플레이어 벨류 초기화
        GameManager.Instance.Text_Gold.text = "Gold :" + m_Player_Value.Gold;
        GameManager.Instance.Text_level_Hp.text = "Level HP :" + m_Player_Value.Level_Hp;
        GameManager.Instance.Text_level_Damege.text = "Level Damege : " + m_Player_Value.Level_Damege;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Btn_Level_Up_Hp()
    {
        m_Player_Value.Get_LevelHp();
    }

    public void Btn_Level_Up_Damege()
    {
        m_Player_Value.Get_LevelDamege();
    }


    public void Set_Text(String Text, UnityEngine.Vector3 pos)
    {
        bool set = false;
        foreach (Text t in Text_List)
        {
            if (!t.gameObject.activeSelf) // 게임오브젝트가 활성 or 비활성 인지 bool 값으로 알려줌
            {
                t.text = Text;
                t.transform.position = Camera.main.WorldToScreenPoint(pos); //WorldTO == 3d 월드 자표를 2d로 바꿔줌
                t.GetComponent<Controller_text>().init();
                set = true;
                break;
            }
        }

        if (!set)
        {
            Text t = Instantiate(Text_Damege, Camera.main.WorldToScreenPoint(pos),
                        UnityEngine.Quaternion.identity).GetComponent<Text>(); //게임오브젝트 복제 증가, 카메라 위치값, 정렬
            t.transform.SetParent(Text_Damege.transform.parent);
            t.text = Text;
            t.GetComponent<Controller_text>().init();
            Text_List.Add(t);
        }
        //텍스트리스트 순환

    }

     public void Set_Text(String Text) //메서드 오버로딩 :: 같은 이름의 메서드를 중복
    {
        bool set = false;
        foreach (Text t in Text_List)
        {
            if (!t.gameObject.activeSelf) // 게임오브젝트가 활성 or 비활성 인지 bool 값으로 알려줌
            {
                t.text = Text;
                t.transform.position = new UnityEngine.Vector2(Screen.width * 0.5f, Screen.height * 0.5f); //WorldTO == 3d 월드 자표를 2d로 바꿔줌
                t.GetComponent<Controller_text>().init();
                set = true;
                break;
            }
        }

        if (!set)
        {
            Text t = Instantiate(Text_Damege,  new UnityEngine.Vector2(Screen.width * 0.5f, Screen.height * 0.5f),
                        UnityEngine.Quaternion.identity).GetComponent<Text>(); //게임오브젝트 복제 증가, 카메라 위치값, 정렬
            t.transform.SetParent(Text_Damege.transform.parent);
            t.text = Text;
            t.GetComponent<Controller_text>().init();
            Text_List.Add(t);
        }
        //텍스트리스트 순환

    }
}
