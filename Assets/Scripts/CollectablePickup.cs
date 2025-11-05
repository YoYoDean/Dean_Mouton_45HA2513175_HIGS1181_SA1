using System.Net.NetworkInformation;
using UnityEngine;

public class CollectablePickup : MonoBehaviour
{
    
    UIManager uIManager;


    void Awake()
    {
      uIManager =  GameObject.FindWithTag("UiManager").GetComponent<UIManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("Detroy");
            
            uIManager.uiScore = uIManager.uiScore += 1;
            
        }
    }

}
