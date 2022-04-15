using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int Width = 5; //플렛폼 길이
    public int height = 5; //플렛폼 높이

    public GameObject Platform;

    public GameObject Character;

    public Transform Platform_Parents;
    private List<GameObject> Platform_List = new List<GameObject>();

    private List<int> Platform_Check_List = new List<int>(); //함정을 만들기 위한 체크리스트

    public GameObject DeadLine;

    public float DeadLine_Speed = 1.0f; // 다가오는 벽의 스피드

    public float DeadLine_Speed_Max = 3.0f; // 다가오는 벽의 최고 스피드

    public float DeadLine_Speed_Accel = 0.1f; // 다가오는 벽에 추가되는 속도

    void Start()
    {
        Data_Load(); //초반 데이터로드
        init(); //초기화
    }

    
    void Data_Load()
    {
        for(int i = 0; i < Width * height; ++i)
        {
                GameObject t_Obj = Instantiate(Platform, Vector3.zero, Quaternion.identity);
                t_Obj.transform.parent = Platform_Parents;
                Platform_List.Add(t_Obj);
                Platform_Check_List.Add(0);
        }

        Platform.SetActive(false);

    }

    public void init() {
        for(int h = 0; h < height; h++)
        {
            for(int w = 0; w < Width; w++)
            {
                Platform_List[Width * h + w].transform.position = new Vector3(-(Width - 1) / 2f + w, -0.5f,h);
                Set_Platform(Width * h + w,Color.green);
            }
        }
        
        Character.transform.position = new Vector3(0f,0.5f,0f);
        DeadLine.transform.position = new Vector3(0f,0.5f,-3f); //데드라인 초기위치
        DeadLine.transform.localScale = new Vector3(Width, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(0);
        }
          if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(1);
        }
          if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(2);
        }

        DeadLine.transform.position += Vector3.forward * DeadLine_Speed *Time.deltaTime;
    }

    public void Move(int direction) 
    {

        bool next_Platform = false; // 키랙터의 전진여부

        switch (direction)
        {
            case 0:
            if(restrict(Vector3.left))
            {
            Character.transform.position += Vector3.left; // Vector3(-1,0,0)
            }
            break;

            case 1:
            if(restrict(Vector3.right))
            {
            Character.transform.position += Vector3.right; // Vector3(-1,0,0)
            }
            break;

            case 2:
            Character.transform.position += Vector3.forward; // Vector3(-1,0,0)
            next_Platform = true;
            break;
        }

        if(next_Platform == true)
        {
            Next_Platform((int)Character.transform.position.z);
        }
     }

    void Next_Platform(int Character_z)
    {
        for(int i = 0; i <= Width; i++)
        {
            Platform_List[((Character_z - 1) % height) * Width + i].transform.position = new Vector3(-Width / 2 + i, -0.5f, (Character_z -1) + height);
        }
    }

    bool restrict(Vector3 diraction)
    {
        Vector3 move_Pos = Character.transform.position + diraction;
        if(move_Pos.x > Width / 2 || move_Pos.x < -Width / 2 ){
             return false;
        }else {
            return true;
        }
    }

    void Set_Platform(int idx,Color color)
    {
        Platform_List[idx].GetComponent<MeshRenderer>().material.color = color;
    }

   
}
