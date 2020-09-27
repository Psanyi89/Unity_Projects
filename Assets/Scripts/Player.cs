using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Enemy enemyCharacter;
    private void Start()
    {
        GlobalDictionaries.AddPlayer("Player", this);
    }

    public void Attack()
    {
        if (enemyCharacter==null)
        {
            enemyCharacter =GlobalDictionaries.GetEnemy("Enemy");
        }
      
            enemyCharacter?.TakeDamage(); 
    }
}
