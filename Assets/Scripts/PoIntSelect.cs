using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PoIntSelect
{
    [SerializeField] private List<Transform> point = new List<Transform>();//��������� ��� ��������
    [HideInInspector] public bool move;//��������� �������� �� �����

    public void DefinePoint(bool first, NavMeshAgent navMeshAgent, Animator animator)
    {
        Debug.Log(point.Count);
        if (point.Count == 1) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        move = true;
        if (!first) point.RemoveAt(0);//���� ��� �� ������ ������� �� �� ������� ���
        navMeshAgent.SetDestination(point[0].position);//��������� ������ �� ������ ������� �������
        animator.SetBool("Run", true);
    }
    public void Stop(NavMeshAgent navMeshAgent, Animator animator)//������������� ��������
    {
        move = false;
        animator.SetBool("Run", false);
    }

}