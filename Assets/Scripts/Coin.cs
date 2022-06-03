using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>(); 
            if (player != null)
            {
                player.AddCoin();
                Destroy(this.gameObject);
            }
            else
            {
                Debug.LogError("Player object not created in ontriggerenter coin.cs");
            }
        }
    }
}
