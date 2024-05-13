using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour
{
    public Animator animator;
    public float damage = 20f;
    public Playerstats stats;
    public float range = 2.5f;
    private bool hitRegistered = false;
    public float hitDelay = 1f; 

    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            ActivateSword();
            if (!hitRegistered)
            {
                CheckForHit();
            }
        }
        else
        {
            DeactivateSword();
        }
    }

    void ActivateSword()
    {
        
        if (animator != null)
        {
            animator.SetBool("IsActive", true);
        }
    }

    void DeactivateSword()
    {
        
        if (animator != null)
        {
            animator.SetBool("IsActive", false);
        }
    }

    void CheckForHit()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
           
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("hit");
                
                EnemyController enemyController = hit.collider.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                   
                    enemyController.TakeDamage(damage + stats.Strengthlevel);
                    hitRegistered = true; 
                    StartCoroutine(ResetHit());
                }
            }
        }
    }

    IEnumerator ResetHit()
    {
        yield return new WaitForSeconds(hitDelay);
        hitRegistered = false; 
    }
}