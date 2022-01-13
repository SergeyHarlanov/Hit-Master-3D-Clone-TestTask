using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private WeaponUsed  _weaponUsed;

    private PoolObj _poolObject = new PoolObj();

    private Movement _movement;

    void Start()
    {
        _poolObject.InitialPool(_prefab.gameObject);//»нициализируем старт значени€
        _movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_movement.DefinionMove())
        {
            Push();
        }
    }
    public void Push()//—оздание экземпл€ра пули использу€ пулл объектов
    {
        Transform tr = this._poolObject.CreatePool().transform;
        tr.position = transform.position;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        tr.position = _weaponUsed.GetCurrentGun()._spaceSpawnBullet.position;

        Physics.Raycast(ray, out RaycastHit hit);

        tr.GetComponent<Rigidbody>().velocity = ((hit.point - tr.position).normalized * 20);
        tr.GetComponent<Bullet>()._movement = _movement;
    }
   
}
[System.Serializable]
public class WeaponUsed
{
    public Weapon[] weapon;
    public int useGunIndex;

    public Weapon GetCurrentGun()
    {
        return weapon[useGunIndex];
    }

    public void NextGun()
    {
        useGunIndex++;
    }
}
[System.Serializable]
public class Weapon
{
    public GameObject prefabGuns;
    public Transform _spaceSpawnBullet;

    public string NameGun;
    public float speed;
}

