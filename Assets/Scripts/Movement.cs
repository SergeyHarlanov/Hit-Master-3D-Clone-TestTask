using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    [SerializeField] private PoIntSelect _pointMovedas = new PoIntSelect();

    public Action OnActionOnTapToplay;

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Point") _pointMovedas.Stop(_navMeshAgent, _animator);
    }

    void Start()
    {
        _animator = GetComponent<Animator>();

        _navMeshAgent = GetComponent<NavMeshAgent>();

        OnActionOnTapToplay += StartGame;
    }
    private void StartGame()
    {
        _pointMovedas.DefinePoint(true, _navMeshAgent, _animator);
    }
    public void CheckIfThereEnemy(Transform transform)
    {
        foreach (Transform item in transform.parent)
        {
            if (item.gameObject.activeSelf)
            {
                return;
            }
        }
        _pointMovedas.DefinePoint(false, _navMeshAgent, _animator);
    }
    public bool DefinionMove()
    {
        return _pointMovedas.move;
    }

}

