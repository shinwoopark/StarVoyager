using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletPos;

    public float FireCoolTime;
    private float _fireCurrentTime;

    private void Update()
    {
        UpdaetInput();
    }

    private void UpdaetInput()
    {
        _fireCurrentTime += Time.deltaTime;

        if (_fireCurrentTime >= FireCoolTime
            && Input.GetKey(KeyCode.Z))
        {
            FireBullet();
            _fireCurrentTime = 0;
        }
    }

    private void FireBullet()
    {
        Instantiate(Bullet, BulletPos.position, Quaternion.identity);
    }
}
