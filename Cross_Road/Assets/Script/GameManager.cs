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

    }

    public void init() {
        for(int h = 0; h < height; h++)
        {
            for(int w = 0; w < Width; w++)
            {
                Platform_List[Width * h + w].transform.position = new Vector3(-(Width - 1) / 2f + w, -0.5f,h);
            }
        }
        
        Character.transform.position = new Vector3(0f,-0.5f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
