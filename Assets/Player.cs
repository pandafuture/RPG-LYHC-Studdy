using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ����һ��������뼯�ı���
    private PlayerInputSet input;
    // ����һ��˽��״̬������
    private StateMachine stateMachine;

    // ����һ�� idle ״̬
    public Player_IdleState idleState {  get; private set; }
    // ����һ�� move ״̬
    public Player_MoveState moveState {  get; private set; }

    // ��ȡ�ƶ������ֵ
    public Vector2 moveInput {  get; private set; }

    private void Awake()
    {
        // ����һ����״̬��ʵ��
        stateMachine = new StateMachine();
        // ����һ���µ�������뼯
        input = new PlayerInputSet();

        // ����һ�� Idle State ��״̬ʵ����Ҫ����״̬��ʵ������״̬��
        idleState = new Player_IdleState(this, stateMachine, "idle");
        // ����һ�� Move State ��״̬ʵ��
        moveState = new Player_MoveState(this, stateMachine, "move");
    }


    // ������Ҷ���ʱ����������ϵͳ
    private void OnEnable()
    {
        // ִ����������
        input.Enable();

        // ��ʼ����
        //input.Player.Movement.started
        // �������£��������ֵ���ƶ��������
        input.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        // ֹͣ���£��������ƶ��������
        input.Player.Movement.canceled += ctx => moveInput = Vector2.zero;
        
    }

    // ������Ҷ���ʱ����������ϵͳ
    private void OnDisable()
    {
        // ִ���������
        input.Disable();
    }


    private void Start()
    {
        // ��ʼ��״̬������ʼ״̬Ϊ idleState
        stateMachine.Initialize(idleState);
    }


    private void Update()
    {
        // ִ�е�ǰ״̬�� Update() ���·���
        stateMachine.currentState.Update();
    }
}
