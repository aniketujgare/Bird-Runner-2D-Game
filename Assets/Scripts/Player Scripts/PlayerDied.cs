using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    public delegate void EndGame();
    public static event EndGame endGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void PlayerDiedEndGame()
    {
        if (endGame!= null)
            endGame();

        Destroy(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag =="Collector")
        {
            PlayerDiedEndGame();
        }
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ostrich" || target.gameObject.tag == "Snake")
        {
            PlayerDiedEndGame();
        }
    }
}
