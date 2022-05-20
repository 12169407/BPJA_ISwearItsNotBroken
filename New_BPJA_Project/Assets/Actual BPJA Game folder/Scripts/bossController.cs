using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bossController : MonoBehaviour
{
    Animator anim;
    public float meleeDistance;
    public float damping;
    public float hp;
    public float maxHP;
    public Transform target;
    public GameObject dieParticles;
    public Image healthbar;
    private int randNum01;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    Vector3 CurrentTargetPos()
    {
        Vector3 playerPos = target.transform.position;

        Vector3 currentPlayerPos = new Vector3(playerPos.x, playerPos.y, playerPos.z);

        return currentPlayerPos;
    }


    // Update is called once per frame
    void Update()
    {
        /*  Vector3 direction = target.position - transform.position;
          Quaternion rotation = Quaternion.LookRotation(direction);
         // rotation.y = 0;
          transform.rotation = rotation;*/
        //transform.LookAt(target);
        HealthBar();


        var lookPos = CurrentTargetPos() - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        //check distance
        var distance = Vector3.Distance(transform.position, target.transform.position);


        if(distance <= meleeDistance)
        {
            //attack melee
            randNum01 = Random.Range(1,4);
            if(randNum01 == 1)
            {
                anim.SetTrigger("melee");
            }
            if (randNum01 == 2)
            {
                anim.SetTrigger("radial");
            }
            if (randNum01 == 3)
            {
                anim.SetTrigger("overdrive");
            }

            
        }
        else
        {
            //attack rangw
            anim.SetTrigger("range");

        }

    }

    void HealthBar()
    {
        healthbar.fillAmount = hp / maxHP;

        if(hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hp -= 4f;
        }
    }

    private void OnDestroy()
    {
        Instantiate(dieParticles, transform.position, transform.rotation);

        
    }
}
