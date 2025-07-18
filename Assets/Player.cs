using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ����һ��˽��״̬������
    private StateMachine stateMachine;

    // ����һ�� idle ״̬
    public Player_IdleState idleState {  get; private set; }
    // ����һ�� move ״̬
    public Player_MoveState moveState {  get; private set; }

    private void Awake()
    {
        // ����һ����״̬��ʵ��
        stateMachine = new StateMachine();

        // ����һ�� Idle State ��״̬ʵ����Ҫ����״̬��ʵ������״̬��
        idleState = new Player_IdleState(this, stateMachine, "idle");
        // ����һ�� Move State ��״̬ʵ��
        moveState = new Player_MoveState(this, stateMachine, "move");
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
