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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 projectile = CalculateProjectileV(shootPoint.position, hitPoint.position, 1f);

        Rigidbody2D firedBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        firedBullet.velocity = projectile;
    }

    Vector2 CalculateProjectileV(Vector2 start, Vector2 target, float t)
    {
        float x, y;
        float vx, vy;

        x = Vector2.Distance(start, target);
        y = Vector2.Distance(target, new Vector2(0,1.5f));

        vx = x / t;
        vy = y / t + 0.5f * -9.81f * t;

        return new Vector2(vx, vy);
    }
}
