using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 10;

    private void Start()
    {
        GlobalDictionaries.AddEnemy($"Enemy", this);
    }

    private void Update()
    {
        if (Health<=0)
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        GlobalDictionaries.RemoveEnemy("Enemy");
    }
    public void TakeDamage()
    {
        Health -= 2;

    }
}
