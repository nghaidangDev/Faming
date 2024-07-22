using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePos;
    [SerializeField] private float TimeBtwFire = 0.2f;
    [SerializeField] private float bulletForce;

    private float timeBtwFire;

    private void Update()
    {
        RotateGun();
        timeBtwFire -= Time.deltaTime;

        if (Input.GetMouseButton(0) && timeBtwFire < 0)
        {
            FireBullet();
        }
    }

    private void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = transform.position - mousePos;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion roration = Quaternion.Euler(0, 0, angle);
        transform.rotation = roration;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }

    private void FireBullet()
    {
        timeBtwFire = TimeBtwFire;

        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        Rigidbody2D rbbullet = bulletTmp.GetComponent<Rigidbody2D>();
        rbbullet.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
