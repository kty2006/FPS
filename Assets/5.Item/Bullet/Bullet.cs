using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    public int time;
    public void Start()
    {
        StartCoroutine(BulletEndTime());
    }
    public void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public IEnumerator BulletEndTime()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
