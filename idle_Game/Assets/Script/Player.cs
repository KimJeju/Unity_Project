using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Charactor // 내가만든 플레이어 상속
{
    public static Player Instance;
    public Charactor Target; // 캐릭터를 자료형으로 하는 타겟

    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        init(100, 1);
    }

    float Attack_Cooltime = 0.0f;
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

    public override void Dead()
    {
        base.Dead();
        Debug.Log("Player Dead");
        Spawn();
    }

    public void Spawn() 
    {
        Hp = HpMax;
        State = Charator_state.idle;

    }

    public void LevelUp(){
        HpMax += HpMax * GameManager.Instance.m_Player_Value.Level_Hp;
        Damege += Damege * GameManager.Instance.m_Player_Value.Level_Damege;
    }
}
