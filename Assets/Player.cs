using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ����һ��˽��״̬������
    private StateMachine stateMachine;

    // ����һ�� idle ״̬
    private EntityState idleState;


    private void Awake()
    {
        // ����һ����״̬��ʵ��
        stateMachine = new StateMachine();

        // ����һ�� Idle State ��״̬ʵ����Ҫ����״̬��ʵ������״̬��
        idleState = new EntityState(stateMachine, "Idle State");
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
