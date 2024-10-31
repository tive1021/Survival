using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int damage;
    public float damageRate;

    private List<IDamagable> things = new List<IDamagable>();

    private void Start()
    {
        StartCoroutine(DealDamageCoroutine());
    }

    private IEnumerator DealDamageCoroutine()
    {
        while (true) // 무한 반복
        {
            DealDamage();
            yield return new WaitForSeconds(damageRate); // damageRate 초 동안 대기
        }
    }

    void DealDamage()
    {
        for (int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(damage);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamagable damagable))
        {
            things.Add(damagable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamagable damagable))
        {
            things.Remove(damagable);
        }
    }
}