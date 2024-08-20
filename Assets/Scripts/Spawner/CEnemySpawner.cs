using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemySpawner : MonoBehaviour
{
    [SerializeField] private Material[] Materials;
    [SerializeField] private GameObject[] EnemyPrefabs;
    [SerializeField] private GameObject[] Spawns;
    [SerializeField] private GameObject[] Bullets;
    private List<GameObject> Enemies = new List<GameObject>();
    private int MaxEnemyCount = 5;// her level 10 arttýr
    private int CurrentEnemyCount = 0;
    private int ConCurrentEnemySpawnCount = 1; //Max 6 3lvl/7lvl/10lvl/14lvl/19lvl
    private float SpawnInterval = 3f;//Each 3lvl divide by 1/3
    private float Timer = 0f;
    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > SpawnInterval && CurrentEnemyCount < MaxEnemyCount)
        {
            GameObject obj = Instantiate(EnemyPrefabs[0], Spawns[0].transform.position, Quaternion.identity);
            obj.GetComponent<CEnemyBase>().InitializeEnemy(10f, 5f, 1f, 3.5f, "melee", 1, "", Materials[0], Bullets[0]);
            obj.GetComponent<CEnemyBase>().EnableEnemy();
            Enemies.Add(obj);
            CurrentEnemyCount += 1;
            Timer = 0f;
        }
        foreach(GameObject obj in Enemies)
        {
            if(obj == null)
            {
                Enemies.Remove(obj);
                CurrentEnemyCount--;
            }
        }
    }

}
