using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_IdleState : EntityState  // 继承 EntityState 类
{
    // 创建构造函数
    public Player_IdleState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {

    }


    public override void Update()
    {
        base.Update();

        // 如果玩家水平移动输入不为 0 ，切换为移动状态
        if (player.moveInput.x != 0)
            stateMachine.ChangeState(player.moveState);
    }
}
