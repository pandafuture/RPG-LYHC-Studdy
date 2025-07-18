using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 声明一个私有状态机变量
    private StateMachine stateMachine;

    // 声明一个 idle 状态
    private EntityState idleState;


    private void Awake()
    {
        // 分配一个新状态机实例
        stateMachine = new StateMachine();

        // 分配一个 Idle State 新状态实例，要传入状态机实例，和状态名
        idleState = new EntityState(stateMachine, "Idle State");
    }


    private void Start()
    {
        // 初始化状态机，初始状态为 idleState
        stateMachine.Initialize(idleState);
    }


    private void Update()
    {
        // 执行当前状态的 Update() 更新方法
        stateMachine.currentState.Update();
    }
}
