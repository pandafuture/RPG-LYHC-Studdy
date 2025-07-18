using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 作为所有状态的父类
public class EntityState  // 不用继承任何类
{
    protected StateMachine stateMachine;  // 声明一个状态机，用来访问
    protected string stateName;  // 状态名


    // 构造函数，为这个类设置默认变量（状态机，状态名）。当创建这个类的新实例时会自动调用
    public EntityState(StateMachine stateMachine ,string stateName)
    {
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }


    // virtual 允许在子脚本上重写这个方法
    // void 可以不用返回任何内容，只会执行方法内部的功能
    public virtual void Enter()
    {
        // 每次进入状态并更改状态时都会调用，初始化状态的一些默认内容
        Debug.Log("I enter " + stateName);
    }


    public virtual void Update()
    {
        // 执行运行状态的逻辑
        Debug.Log("I run update of " + stateName);
    }


    public virtual void Exit()
    {
        // 每次退出状态并更改为新状态时调用
        Debug.Log("I exit " + stateName);
    }
}
