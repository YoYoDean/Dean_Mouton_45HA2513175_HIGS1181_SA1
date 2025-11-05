using System.Net.NetworkInformation;
using JetBrains.Annotations;
using UnityEngine;


public class CollectablePickup : MonoBehaviour
{

    UIManager uIManager;

    private Rigidbody2D playerPos;
    private Rigidbody2D enemyPos;

    private Vector3 vector3playerPos;
    private Vector3 vector3enemyPos;


    void Awake()
    {
        uIManager = GameObject.FindWithTag("UiManager").GetComponent<UIManager>();
    }

    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        enemyPos = GameObject.FindWithTag("Enemy").GetComponent<Rigidbody2D>();

        vector3playerPos = playerPos.transform.position; 
        vector3enemyPos = enemyPos.transform.position; 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("Detroy");

            uIManager.uiScore = uIManager.uiScore += 1;
            playerPos.transform.position = vector3playerPos;
            enemyPos.transform.position = vector3enemyPos;

            
        }
    }
    


}
