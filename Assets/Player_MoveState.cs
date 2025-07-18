using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MoveState : EntityState  // 继承自 EntityState 类
{
    // 生成构造函数
    public Player_MoveState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }


    public override void Update()
    {
        base.Update();


        // 如果玩家的水平移动输入为 0 ，切换到空闲状态
        if (player.moveInput.x == 0)
            stateMachine.ChangeState(player.idleState);
    }
}
