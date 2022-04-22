using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Charactor // 내가만든 플레이어 상속
{
   public Charactor Target; // 캐릭터를 자료형으로 하는 타겟
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
