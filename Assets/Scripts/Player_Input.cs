using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    public Player playerCharacter;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Attacking!");
            
            playerCharacter =GlobalDictionaries.GetPlayer("Player");

            playerCharacter?.Attack();
        }
    }
}
