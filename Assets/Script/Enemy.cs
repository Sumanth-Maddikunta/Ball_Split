using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    Vector2 direction;
    float speed = 5f;

    int initialHealth = 10;
    public int health = 10;
   
    Vector2 size;


    Rigidbody rb;
    public GameObject enemyPrefab;

    private void Start()
    {
        health = initialHealth;
        rb = GetComponent<Rigidbody>();
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(0.0f, -1.0f);
        direction = new Vector2(x, y)*speed;
        rb.velocity = direction;
        size = transform.localScale;

        
        //Debug.Log(direction);
    }
    Enemy(float size=3)
    {
        transform.localScale=new Vector3(size,size,size)/2;
    }
    private void Update()
    {
        transform.position +=(Vector3 )direction * speed * Time.deltaTime;
        CheckHealth();
        CheckSize();
    }
    void CheckHealth()
    {
        if(health<0)
        {
            
            //Instantiate Enemies
            GameObject obj1 = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            obj1.GetComponent<Enemy>().initialHealth = initialHealth / 2;
            obj1.transform.localScale = transform.localScale / 2;
            obj1.GetComponent<Rigidbody>().AddForce(new Vector2(-1, 1) * 5, ForceMode.Impulse);

            GameObject obj2 = Instantiate(enemyPrefab, transform.position+Vector3.right, Quaternion.identity);
            obj2.GetComponent<Enemy>().initialHealth = initialHealth / 2;
            obj2.transform.localScale = transform.localScale / 2;
            obj2.GetComponent<Rigidbody>().AddForce(new Vector2(1, 1) * 5, ForceMode.Impulse);

            Destroy(this.gameObject);
            
        }
    }
    void CheckSize()
    {
        if(transform.localScale.magnitude<Vector3.one.magnitude/5)
        {
            Destroy(this.gameObject);
            Debug.Log("Destroy enemy");
        }
    }
     
}



