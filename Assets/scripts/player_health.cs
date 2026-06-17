using UnityEditorInternal;
using UnityEngine;

public class player_health : MonoBehaviour
{
    public int health;
    public int maxHealth;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Debug.Log("death");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
        
    }
}

