using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PoIntSelect
{
    [SerializeField] private List<Transform> point = new List<Transform>();//вейпоинты дл€ движени€
    [HideInInspector] public bool move;//указывает движетс€ ли герой

    public void DefinePoint(bool first, NavMeshAgent navMeshAgent, Animator animator)
    {
        Debug.Log(point.Count);
        if (point.Count == 1) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        move = true;
        if (!first) point.RemoveAt(0);//≈сли это не первый уровень то мы удал€ем его
        navMeshAgent.SetDestination(point[0].position);//указываем таргет на первый элемент массива
        animator.SetBool("Run", true);
    }
    public void Stop(NavMeshAgent navMeshAgent, Animator animator)//останавливаем анимацию
    {
        move = false;
        animator.SetBool("Run", false);
    }

}