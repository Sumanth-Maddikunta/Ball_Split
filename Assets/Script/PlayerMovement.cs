using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    //Player Variables
    public float speed = 5f;
    Vector2 movement;
    Rigidbody rb;
    //Player Variables End

    //Shooting Variables
    public GameObject bulletPrefab;
    public Queue<Transform> bulletPool;
    public int ammo = 50;
    //Shooting Variables End

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        bulletPool = new Queue<Transform>();
        for(int i=0;i<ammo;i++)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.localEulerAngles = new Vector3(bullet.transform.localRotation.x, bullet.transform.localRotation.y, 45.0f);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet.transform);
        }
       
        //Debug.Log(Physics.gravity);
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Shoot();
	}
    private void Move()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        rb.velocity = movement;
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform bullet = bulletPool.Dequeue();
            bullet.position = transform.position + Vector3.up;
            bullet.gameObject.SetActive(true);
            bullet.GetComponent<Bullet>().didEnqueue = true;
            
        }
    }
}
