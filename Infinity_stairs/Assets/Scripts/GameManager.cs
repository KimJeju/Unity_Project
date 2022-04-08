using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public bool Game_Start = false; //게임시작체크

    public float Current_Time = 0.0f; //현재 남은 시간을 의미

    public float Destination_Time = 10.0f; //전체시간

    public float Add_Time_Flow = 0.001f; // 감소 시간

    public Slider Slider; // 시간 

    public Text Text;

    public int Score = 0;

    public GameObject Character; // 캐릭터

    public Transform Platform_Parents; // 정리를 위한 발판들의 부모 오브젝트

    public GameObject Platform; // 발판

    private List<GameObject> Platform_List = new List<GameObject>(); // 발판의 리스트

    private List<int> Platform_checkList = new List<int>(); // 발판의 위치 리스트, 왼쪽 : 0 || 오른쪽 : 1

    // Start is called before the first frame update
    void Start()
    {
        Data_Load();
        init();
    }
    // Update is called once per frame
    void Update()
    {
        if (Game_Start == true) //키보드 입력체크
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Check_Platform(Character_Pos_Idx, 1);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Check_Platform(Character_Pos_Idx, 0);
            }

            Destination_Time = Destination_Time - Add_Time_Flow;
            Current_Time = Current_Time - Time.deltaTime;

            Slider.value =  Current_Time / Destination_Time;

            if(Current_Time < 0f){
                Result();
            }

          
        }else{
            if(Input.GetKeyDown(KeyCode.Space)){
                init();
            }
        }
    }

    public void Data_Load() // 데이터로드, 발판 오브젝트 생성
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject t_Obj = Instantiate(Platform, Vector3.zero, Quaternion.identity);
            t_Obj.transform.parent = Platform_Parents;
            Platform_List.Add(t_Obj);
            Platform_checkList.Add(0);
        }

        Platform.SetActive(false);
    }

    private int Pos_Idx = 0; // 발판의 마지막 위치 저장
    private int Character_Pos_Idx = 0; // 캐릭터의 위치

    public void init() // 캐릭터의 위치, 발판의 위치 초기화
    {
        Character.transform.position = Vector3.zero;

        for (Pos_Idx = 0; Pos_Idx < 20;)
        {
            Next_Platform(Pos_Idx);
        }

        Destination_Time = 10.0f;
        Current_Time = Destination_Time;

        Character_Pos_Idx = 0;
        Score = 0;
        Text.text = Score.ToString();
        Game_Start = true;
    }


    public void Next_Platform(int idx)
    {
        int Pos = Random.Range(0, 2);

        if (idx == 0) //첫번째 발판의 경우
        {
            Platform_List[idx].transform.position = new Vector3(0, -0.5f, 0);
        }
        else
        {
            if (Pos_Idx < 20)
            {
                if (Pos == 0)
                { //왼쪽발판일 경우
                    Platform_checkList[idx - 1] = Pos;
                    Platform_List[idx].transform.position = Platform_List[idx - 1].transform.position + new Vector3(-1f, 0.5f, 0);
                }
                else
                { // 오른쪽 발판일 경우
                    Platform_checkList[idx - 1] = Pos;
                    Platform_List[idx].transform.position = Platform_List[idx - 1].transform.position + new Vector3(1f, 0.5f, 0);
                }
            }else{
                if (Pos == 0)
                { 
                    if(idx % 20 == 0)
                    {
                    //왼쪽발판일 경우
                    Platform_checkList[20 - 1] = Pos;
                    Platform_List[idx % 20].transform.position = Platform_List[20 - 1].transform.position + new Vector3(-1f, 0.5f, 0);
                    }else{
                    Platform_checkList[idx % 20 - 1] = Pos;
                    Platform_List[idx % 20].transform.position = Platform_List[idx % 20 - 1].transform.position + new Vector3(-1f, 0.5f, 0);
                    }
                
                }else{ 
                    // 오른쪽 발판일 경우
                    if(idx % 20 == 0)
                    {
                    Platform_checkList[20 - 1] = Pos;
                    Platform_List[idx % 20].transform.position = Platform_List[20 - 1].transform.position + new Vector3(1f, 0.5f, 0);
                    }else{
                    Platform_checkList[idx % 20 - 1] = Pos;
                    Platform_List[idx % 20].transform.position = Platform_List[idx % 20 - 1].transform.position + new Vector3(1f, 0.5f, 0);
                    }
                }
            }

        }
        Score++;
        Text.text = Score.ToString();
        Pos_Idx++;
    }

    void Check_Platform(int idx, int Direction)
    {
        Debug.Log("Idx : "+ idx % 20 + " /Platform : "+ Platform_checkList[idx %20] + " /Direction : "+ Direction); 
        if(Platform_checkList[idx % 20] == Direction){ // 발판이 있음
            Character_Pos_Idx++;
            Character.transform.position = Platform_List[Character_Pos_Idx % 20].transform.position + new Vector3(0f, 0.5f, 0);
            Next_Platform(Pos_Idx);
        }else{
            Result();
        }
    }

    public void Result()
    {
        Debug.Log("Game Over");
        Game_Start = false;
    }
}

