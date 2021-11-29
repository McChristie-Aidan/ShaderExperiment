using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    int DamageAmount { get; }
    Material DeathMaterial { get; }
    void HitEffect(GameObject targetHit);
    void Kill(IDamagable subject);
    void Kill(IDamagable subject, float timeTilDeath);
}
