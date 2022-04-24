using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : Charactor // MonoBehaviour 가 아닌 캐릭터를 타겟
{

    public Charactor Target;
    // Start is called before the first frame update
    void Start()
    {
        init(10,1); //몬스터 기본 체력, 공격력
    }

    float Attack_Cooltime = 0.0f; // 공격행동이 일정한 행동 이후에 할 수 있도록 만듬

    // Update is called once per frame
    void Update()
    {
      if(Attack_Cooltime < Attack_Speed)
      {
          Attack_Cooltime += Time.deltaTime; // 쿨타임 증가하다 어택스피드와 같아지면 공격 실행
      }else{
          HitDamege(Target, Damege); // 어택스피드와 같아지면 HitDamege 함수 출력
          Attack_Cooltime = 0.0f; // 공격이 끝나면 초기화
      }
    }
}
