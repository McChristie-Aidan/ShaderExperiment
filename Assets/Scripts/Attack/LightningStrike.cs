using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour, IAttack
{

    [SerializeField]
    int damageAmount = 1;
    [SerializeField]
    float activeTime = .2f;
    float colliderTimeStamp;
    [SerializeField]
    float LaunchHeight = 7f;
    [SerializeField]
    float SideLaunch = 3f;
    [SerializeField]
    float RotationSpeed = 2f;
    [SerializeField]
    float dissolveDuration = .5f;
    public int DamageAmount
    {
        get => damageAmount;
        set
        {
            damageAmount = value;
        }
    }

    [SerializeField]
    Material deathMaterial;
    public Material DeathMaterial 
    { 
        get => deathMaterial;
        set
        {
            deathMaterial = value;
        }
    }

    private void Start()
    {
        colliderTimeStamp = Time.time + activeTime;
    }
    private void Update()
    {
        if (colliderTimeStamp <= Time.time)
        {
            if (this.GetComponent<Collider>() != null)
            {
                this.GetComponent<Collider>().enabled = false;
            }
        }
    }
    public void HitEffect(GameObject other)
    {
        Debug.Log("Object Hit");
        if (other.GetComponent<IDamagable>() != null || other.GetComponentInChildren<IDamagable>() != null)
        {
            IDamagable damagable = other.GetComponent<IDamagable>();
            damagable.TakeDamage(damageAmount);
            if (damagable.Health <= 0)
            {
                Kill(damagable, dissolveDuration);
                DeathEffect(other);
            }
        }
    }
    public void Kill(IDamagable subject)
    {
        Kill(subject, 0);
    }
    public void Kill(IDamagable subject, float timeTilDeath)
    {
        subject.Die(timeTilDeath);       
    }
    public void DeathEffect(GameObject gameObject)
    {      
        ApplyDeathMaterial(gameObject);
        if (gameObject.GetComponent<Rigidbody>() != null)
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();

            //this could be utility
            Debug.Log("adding launch forces");
            Vector3 force = new Vector3(
                Random.Range(-SideLaunch, SideLaunch),
                Random.Range(LaunchHeight/2,LaunchHeight),
                Random.Range(-SideLaunch, SideLaunch));

            rb.AddForce(force, ForceMode.Impulse);

            Vector3 torque = new Vector3(
                Random.Range(-RotationSpeed, RotationSpeed),
                Random.Range(-RotationSpeed, RotationSpeed),
                Random.Range(-RotationSpeed, RotationSpeed));

            rb.AddTorque(torque, ForceMode.Impulse);
        }
    }
    public void ApplyDeathMaterial(GameObject gameObject)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer.material.color != null)
        {
            Color temp = renderer.material.color;
            renderer.material = deathMaterial;
            renderer.material.SetColor("BaseColor", temp);
            StartCoroutine(Dissolve(renderer, dissolveDuration));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        HitEffect(other.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        HitEffect(collision.gameObject);
    }
    IEnumerator Dissolve(Renderer renderer, float dissolveDuration)
    {
        float dissolveValue = 0f;

        while (dissolveValue < 1f)
        {
            dissolveValue += Time.deltaTime / dissolveDuration;
            dissolveValue = Mathf.Clamp(dissolveValue, -1.1f, 1f);
            if (renderer != null)
            {
                renderer.material.SetFloat("DissolveValue", dissolveValue);
            }
            yield return null;
        }
    }
}
