using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    int Health { get; }
    void TakeDamage();
    void TakeDamage(int DamageAmount);
    void Die();
    void Die(float timeTilDeath);
}
