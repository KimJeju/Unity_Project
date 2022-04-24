using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;                  //BigInteger를 사용하기 위해서 선언
using System.Numerics;         // Numerics 네임스페이스를 선언해야 BigInterger를 사용할 수 있다.

public class Charactor : MonoBehaviour
{
   
  /*
  BigInterger를 선언해준 이유는 게임 후반 Player의 체력과 같은 수치가 매우 큰값이 되었을 시 int형으로 담을 수 없기 때문
  */
  public BigInteger Hp;  // Player 체력
  
  public BigInteger HpMax;  // Player가 가지는 최대 HP

  public BigInteger Damege; // Player가 받은 데미지

  public float Attack_Speed; //플레이어 공격속도.

  public void init(BigInteger hp, BigInteger damege)  // 함수 초기화
  {
     HpMax = hp;
        Hp = HpMax;
        Damege = damege;
        Attack_Speed = 1.0f;
  } // 초기화를 위한 함수

  public void GetHp(BigInteger hp) // 현재 Hp가 HpMax보다 커지게된다면 HpMax와 동일하게 세팅해준다.
  {
        Hp += hp; 

        if(Hp > HpMax)
        {
            Hp = HpMax;
        }
  } 

 /*
 GetDamage 메서드와 HitDamege 메서드는 플레어와 에너미가 동시에 상속 받을 메서드이다.
 */

  public void getDamege(BigInteger damege) //받는 데미지를 표현하기 위한 메서드
  {
      Hp -= damege;

      if(Hp <= 0) //플레이어 체력이 0이되면 Dead() 메서드를 호출해준다.
      {
          Dead();
      }
  }

  public void HitDamege(Charactor Target, BigInteger damege) // 데미지를 주는 메서드
  {
        Target.getDamege(damege);
  }

  
  public void Dead() 
  {
      Debug.Log("DEAD");
  }


}
