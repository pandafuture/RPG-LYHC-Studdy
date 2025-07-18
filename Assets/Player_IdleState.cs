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

        // 按下 F 键，切换为移动状态
        if (Input.GetKeyDown(KeyCode.F))
            stateMachine.ChangeState(player.moveState);
    }
}
