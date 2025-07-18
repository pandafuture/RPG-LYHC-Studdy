using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    // 引用当前活动的状态，封装并保护它。刚创建时是没有指定状态的
    public EntityState currentState {  get; private set; }


    // 初始化开始状态
    public void Initialize(EntityState startState)
    {
        // 分配开始状态
        currentState = startState;

        // 进入状态
        currentState.Enter();
    }


    // 改变状态
    public void ChangeState(EntityState newState)
    {
        // 退出当前状态
        currentState.Exit();

        // 分配新状态
        currentState = newState;

        // 进入新状态
        currentState.Enter();
    }
}