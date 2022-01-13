using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public Movement _movement;
    private void Start()
    {
        Invoke(nameof(Deactive), 2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Build")
        {
            gameObject.SetActive(false);
        }
        if (other.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            _movement.CheckIfThereEnemy(other.transform);
            gameObject.SetActive(false);
        }
    }
    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
