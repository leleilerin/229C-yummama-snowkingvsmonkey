using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform shootPoint, hitPoint;
    [SerializeField] private Rigidbody2D bulletPrefab;
    private bool isPlayer1;
    private float cooldown = 0.5f;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        isPlayer1 = gameObject.GetComponent<PlayerControl>().IsPlayer1();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            if (Input.GetKeyDown(KeyCode.W) && Time.time > timer)
            {
                Vector2 projectile = CalculateProjectileV(shootPoint.position, hitPoint.position, 1f, isPlayer1);

                Rigidbody2D firedBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
                firedBullet.linearVelocity = projectile;
                timer = Time.time + cooldown;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && Time.time > timer)
            {
                Vector2 projectile = CalculateProjectileV(shootPoint.position, hitPoint.position, 1f, isPlayer1);

                Rigidbody2D firedBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
                firedBullet.linearVelocity = projectile;
                timer = Time.time + cooldown;
            }
        }
    }

    Vector2 CalculateProjectileV(Vector2 start, Vector2 target, float t, bool one)
    {
        Vector2 distance = target - start;

        float distX = distance.x;
        float distY = distance.y;

        float veloX = distX / t;
        float veloY = distY / t + 0.9f * Mathf.Abs(Physics2D.gravity.y) * t;
        
        return new Vector2(veloX, veloY);;

        /*float x, y;
        float vx, vy;

        x = Vector2.Distance(start, target);
        y = Vector2.Distance(target, new Vector2(target.x, start.y));

        vx = x / t;
        vy = y / t + 0.5f * 9.81f * t;

        if (!one)
        {
            vx = -vx;
        }

        return new Vector2(vx, vy);*/
    }
}
