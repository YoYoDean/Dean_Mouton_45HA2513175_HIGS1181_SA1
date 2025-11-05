using System.Net.NetworkInformation;
using JetBrains.Annotations;
using UnityEngine;


public class CollectablePickup : MonoBehaviour
{
    //declaring variables
    UIManager uIManager;

    private Rigidbody2D playerPos;
    private Rigidbody2D enemyPos;

    private Vector3 vector3playerPos;
    private Vector3 vector3enemyPos;


    void Awake()
    {
        uIManager = GameObject.FindWithTag("UiManager").GetComponent<UIManager>(); //find uimanager and getting acces to script
    }

    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        enemyPos = GameObject.FindWithTag("Enemy").GetComponent<Rigidbody2D>(); // getting access to rigidbodies

        vector3playerPos = playerPos.transform.position; // saving positions of player and enemy
        vector3enemyPos = enemyPos.transform.position; 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  //checking if player entered collider
        {
            Destroy(this.gameObject); //remove goal object
            Debug.Log("Detroy");

            uIManager.uiScore = uIManager.uiScore += 1;  //adding score to ui
            playerPos.transform.position = vector3playerPos;  //moving player and enemy back to start
            enemyPos.transform.position = vector3enemyPos;

            
        }
    }
    


}
