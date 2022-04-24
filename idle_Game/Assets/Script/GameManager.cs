using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;                  //BigInteger를 사용하기 위해서 선언
using System.Numerics;         // Numerics 네임스페이스를 선언해야 BigInterger를 사용할 수 있다. 닷넷에 포함된 기본숫자형에 새로운 숫자형 포함
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
        }

        public void Get_LevelHp() //레벨을 올리기 위한 메서드
        {
            Level_Hp += 1;
        }
        public void Get_LevelDamege() //데미지를 올리기 위한 메서드
        {
            Level_Damege += 10;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
