using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlay : MonoBehaviour
{
    [SerializeField] private Movement _movement;

    [SerializeField] private GameObject[] _objectDeactive;
    private void Awake()
    {
        _movement.OnActionOnTapToplay += DeactiveObject;
    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _movement.OnActionOnTapToplay();
        }
    }
    public void DeactiveObject()//отключаем объекты при нажатии кнопки
    {
        foreach (var item in _objectDeactive)
        {
            item.SetActive(false);
        }
        this.enabled = false;
    }
}
