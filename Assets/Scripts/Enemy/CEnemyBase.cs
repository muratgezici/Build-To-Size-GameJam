using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CEnemyBase : MonoBehaviour
{
    private float health = 10f;
    private float damage = 5f;
    private float attack_spd = 1f;
    private float move_spd = 3.5f;
    private string range_type = "melee";
    private int size = 1;
    private string resistance_type = "";
    private bool is_slowed = false;
    private bool is_burning = false;
    private Material Material;
    private GameObject BulletPrefab;

    private float Timer = 0f;
    private float TimeInterval = 3f;
    private GameObject AttBuilding;
    public void InitializeEnemy(float _health, float _damage, float _attack_spd, float _move_spd, string _range_type, int _size, string _resistance_type, Material _mat, GameObject _bullet)
    {
        health = _health;
        damage = _damage;
        attack_spd = _attack_spd;
        move_spd = _move_spd;
        range_type = _range_type;
        size = _size;
        resistance_type = _resistance_type;
        Material = _mat;
        BulletPrefab = _bullet;
    }
    public void EnableEnemy()
    {
        gameObject.GetComponent<NavMeshAgent>().speed = move_spd;
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material = Material;
        gameObject.transform.GetChild(0).transform.localScale *= size;
        TimeInterval /= attack_spd;
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (gameObject.GetComponent<NavMeshAgent>().velocity == new Vector3(0, 0, 0))
        {
            if(Timer > TimeInterval)
            {
                Attack();
                Timer = 0;
            }
        }
        else
        {
            Timer = 0f;
        }
    }
    private void Attack()
    {
        AttBuilding = gameObject.GetComponent<CEnemyMove>().GetBuilding();
        if(AttBuilding != null)
        {
            GameObject bullet = Instantiate(BulletPrefab);

            //Instantaite a bullet going to atkbuilding with given damage. if meele instantiate ghost bullet.
        }
    }
    public void SetIsSlowed(bool val)
    {
        is_slowed = val;
    }
    public void SetIsBurning(bool val)
    {
        is_burning = val;
    }
    public void DecreaseHealth(float damage)
    {
        health -= damage;
        if(health < 0)
        {
            Die();
        }
    }
    private void Die()
    {
        //
    }
}
