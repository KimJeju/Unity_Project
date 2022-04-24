using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : Charactor // MonoBehaviour 가 아닌 캐릭터를 타겟
{

    public Charactor Target;
    // Start is called before the first frame update
    void Start()
    {
        init(10, 1); //몬스터 기본 체력, 공격력
    }

    float Attack_Cooltime = 0.0f; // 공격행동이 일정한 행동 이후에 할 수 있도록 만듬

    // Update is called once per frame
    void Update()
    {
        if (State == Charator_state.death) //죽어있는 상태라면 종료
        {
            return;
        }

        if (Attack_Cooltime < Attack_Speed)
        {
            Attack_Cooltime += Time.deltaTime; // 쿨타임 증가하다 어택스피드와 같아지면 공격 실행
        }
        else
        {
            HitDamege(Target, Damege); // 어택스피드와 같아지면 HitDamege 함수 출력
            Attack_Cooltime = 0.0f; // 공격이 끝나면 초기화
        }
    }

    public override void Dead() //자식 키워드에서는 메서드를 재정의 할 시 void 앞에 override를 붙여줘야한다
    {
        base.Dead(); //base는 dead라는 키워드를 사용해 부모데드에서와 똑같이 사용되도록 한다.
        Debug.Log("Enermy Dead");
        GameManager.Instance.m_Player_Value.Get_Gold(Gold);
        Spawn();
    }

    public int Lv_Up = 200;
    public int Lv_Damege = 200;
    public int Lv_Gold = 200;

    public void Spawn() //몬스터 업그레이드 플레이어 골드 주기
    {
        HpMax += HpMax * Lv_Up / 100;
        // HpMax = 10 + 10 * 200 / 100 = 30
        Damege += Damege * Lv_Damege / 100;
        // Damege = 1 + 1 * 200 / 100 = 4;
        Gold += Gold * Lv_Gold / 100;
        Hp = HpMax;
        State = Charator_state.idle;

    }
}
