using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    Vector3 direction;
    public float speed = 20f;
    public bool didEnqueue = true;
    GameObject player;
    public int bulletDamage = 5;
    // Use this for initialization
    void Start()
    {
        direction = Vector2.up;

        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (didEnqueue)
        {
            didEnqueue = false;
            Invoke("OnPool", 1f);
        }
    }
    void OnPool()
    {
        gameObject.SetActive(false);
        //transform.GetComponentInParent<PlayerMovement>().bulletPool.Enqueue(this.transform);
        player.GetComponent<PlayerMovement>().bulletPool.Enqueue(this.transform);

    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit");
        if (other.gameObject.tag=="Enemy")
        {
            Debug.Log("Hit");
            other.GetComponent<Enemy>().health -= 5;
            Debug.Log(other.GetComponent<Enemy>().health);
            OnPool();
        }
    }
    
    
}
