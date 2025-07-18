using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MoveState : EntityState  // �̳��� EntityState ��
{
    // ���ɹ��캯��
    public Player_MoveState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }


    public override void Update()
    {
        base.Update();


        // ���� G �����л�������״̬
        if (Input.GetKeyDown(KeyCode.G))
            stateMachine.ChangeState(player.idleState);
    }
}
