using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 声明一个玩家输入集的变量
    private PlayerInputSet input;
    // 声明一个私有状态机变量
    private StateMachine stateMachine;

    // 声明一个 idle 状态
    public Player_IdleState idleState {  get; private set; }
    // 声明一个 move 状态
    public Player_MoveState moveState {  get; private set; }

    // 获取移动输入的值
    public Vector2 moveInput {  get; private set; }

    private void Awake()
    {
        // 分配一个新状态机实例
        stateMachine = new StateMachine();
        // 分配一个新的玩家输入集
        input = new PlayerInputSet();

        // 分配一个 Idle State 新状态实例，要传入状态机实例，和状态名
        idleState = new Player_IdleState(this, stateMachine, "idle");
        // 分配一个 Move State 新状态实例
        moveState = new Player_MoveState(this, stateMachine, "move");
    }


    // 启用玩家对象时，启用输入系统
    private void OnEnable()
    {
        // 执行输入启用
        input.Enable();

        // 开始按下
        //input.Player.Movement.started
        // 持续按下，会分配新值给移动输入变量
        input.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        // 停止按下，会重置移动输入变量
        input.Player.Movement.canceled += ctx => moveInput = Vector2.zero;
        
    }

    // 禁用玩家对象时，禁用输入系统
    private void OnDisable()
    {
        // 执行输入禁用
        input.Disable();
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
