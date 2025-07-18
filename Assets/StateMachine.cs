using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    // ���õ�ǰ���״̬����װ�����������մ���ʱ��û��ָ��״̬��
    public EntityState currentState {  get; private set; }


    // ��ʼ����ʼ״̬
    public void Initialize(EntityState startState)
    {
        // ���俪ʼ״̬
        currentState = startState;

        // ����״̬
        currentState.Enter();
    }


    // �ı�״̬
    public void ChangeState(EntityState newState)
    {
        // �˳���ǰ״̬
        currentState.Exit();

        // ������״̬
        currentState = newState;

        // ������״̬
        currentState.Enter();
    }
}