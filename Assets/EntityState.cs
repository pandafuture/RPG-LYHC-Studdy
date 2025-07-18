using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ��Ϊ����״̬�ĸ���
// abstract ֻ����Ϊ��������ͼ���޷�ֱ��ʹ�ã����Ҫʹ�þ�ֻ�ܼ̳� EntityState �����ʹ��
public abstract class EntityState  // ���ü̳��κ���
{
    protected Player player;  // ����һ����ұ���
    protected StateMachine stateMachine;  // ����һ��״̬������������
    protected string stateName;  // ״̬��


    // ���캯����Ϊ���������Ĭ�ϱ�������ң�״̬����״̬��������������������ʵ��ʱ���Զ�����
    public EntityState(Player player, StateMachine stateMachine, string stateName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }


    // virtual �������ӽű�����д�������
    // void ���Բ��÷����κ����ݣ�ֻ��ִ�з����ڲ��Ĺ���
    public virtual void Enter()
    {
        // ÿ�ν���״̬������״̬ʱ������ã���ʼ��״̬��һЩĬ������
        Debug.Log("I enter " + stateName);
    }


    public virtual void Update()
    {
        // ִ������״̬���߼�
        Debug.Log("I run update of " + stateName);
    }


    public virtual void Exit()
    {
        // ÿ���˳�״̬������Ϊ��״̬ʱ����
        Debug.Log("I exit " + stateName);
    }
}
