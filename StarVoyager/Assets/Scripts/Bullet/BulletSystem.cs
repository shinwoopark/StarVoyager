using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    public float BUlletDir;

    public float BulletSpeed;

    private void Start()
    {
        SetRotation();
    }

    private void FixedUpdate()
    {
        UpdateMove();
    }

    private void SetRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, BUlletDir);
    }

    private void UpdateMove()
    {
        transform.position += new Vector3(0, BulletSpeed, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BorderBullet")
        {
            Destroy(gameObject);
        }
    }
}
