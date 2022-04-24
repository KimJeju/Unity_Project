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


        public void Get_Gold(BigInteger Value) //골드를 받기 위한 메서드, 1이 아닌 특정한 값을 받기위해 Biginteger Value를 받게 해준다.
        {
            Gold += Value;
            GameManager.Instance.Text_Gold.text = "Gold : " + Gold;

        }

        public void Get_LevelHp() //레벨을 올리기 위한 메서드
        {
            Level_Hp += 1;
            GameManager.Instance.Text_level_Hp.text = "Level HP : " + Level_Hp;
        }
        public void Get_LevelDamege() //데미지를 올리기 위한 메서드
        {
            Level_Damege += 1;
            GameManager.Instance.Text_level_Damege.text = "Level Damege : " + Level_Damege;

        }
    }

    public static GameManager Instance; //게임매니저를 자료형으로 가지는 인스턴스 선언, Static 메서드로 정적으로 선언
    public Text Text_Gold;
    public Text Text_level_Hp;
    public Text Text_level_Damege;
    public Player_Value m_Player_Value;

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
        GameManager.Instance.Text_level_Damege.text = "Level Damege" + m_Player_Value.Level_Damege;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
