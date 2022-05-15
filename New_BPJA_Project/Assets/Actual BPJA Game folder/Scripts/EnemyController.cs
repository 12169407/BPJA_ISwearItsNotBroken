using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int speed;
    private Transform player;
    private Animator enemyAnim;
    private GameObject enemy;
    public int enemyHealth = 3;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyAnim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 localPosition = player.transform.position - transform.position;
        localPosition = localPosition.normalized;
        transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
        transform.LookAt(player);
        enemyAnim.SetInteger("runWolf",1);
        if(enemyHealth <= 0)
        {
            Destroy(enemy);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Sword"))
        {
            enemyAnim.SetInteger("hurtWolf", 4);
            enemyHealth--;
        }
        else
        {
            enemyAnim.SetInteger("hurtWolf", 0);

        }
        if(collision.collider.CompareTag("Player"))
        {
            enemyAnim.SetInteger("attackWolf", 3);
            Debug.Log("player hit");
        }
    }
    public void stopAnimation(string anim)
    {
        enemyAnim.SetInteger(anim, 0);

    }
}
