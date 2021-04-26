using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType3 : MonoBehaviour
{
    float time;
    float nextFire;
    [SerializeField]
     GameObject projectile;

    GameObject shootPoint;
    Animator animator;

    private void Start()
    {
        shootPoint = transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
        if (gameObject.transform.parent.gameObject.tag == "EnemyShootSlow")
        {
            nextFire = 2f;
        }
        else if (gameObject.transform.parent.gameObject.tag == "EnemyShootFast")
        {
            nextFire = 0.5f;
        }
    }
    void Update()
    {
        CheckIfTimeTofire();
    }
    void CheckIfTimeTofire()
    {
        if (time >=nextFire)
        {
            animator.SetTrigger("PenginAttack");
            GameObject projectileObj=Instantiate(projectile, shootPoint.transform.position, Quaternion.identity);
            projectileObj.GetComponent<projectileEnemy>().owner = transform.parent.transform.gameObject;
            time = 0;
        }
        time += Time.deltaTime;
    }

   
}
