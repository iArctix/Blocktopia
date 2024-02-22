using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float lifetime = 10f; 
    public float damage = 10f; 
    public bool isStuck = false; 

    void Start()
    {
       
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                
                enemyController.TakeDamage(damage);
            }

           
            Destroy(gameObject);
        }
        
        else if (collision.gameObject.CompareTag("Environment"))
        {
            
            isStuck = true;

           
            Rigidbody arrowRigidbody = GetComponent<Rigidbody>();
            if (arrowRigidbody != null)
            {
                arrowRigidbody.isKinematic = true;
                arrowRigidbody.detectCollisions = false;
            }

            
            transform.parent = collision.transform;
        }
    }
}