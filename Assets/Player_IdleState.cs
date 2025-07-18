using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_IdleState : EntityState  // �̳� EntityState ��
{
    // �������캯��
    public Player_IdleState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {

    }


    public override void Update()
    {
        base.Update();

        // ������ˮƽ�ƶ����벻Ϊ 0 ���л�Ϊ�ƶ�״̬
        if (player.moveInput.x != 0)
            stateMachine.ChangeState(player.moveState);
    }
}
