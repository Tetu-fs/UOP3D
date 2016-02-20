using UnityEngine;
using System.Collections;

public class enemyGen : MonoBehaviour
{

    public GameObject EnemyParent;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject BOSS = GameObject.FindGameObjectWithTag("Boss");

        GameObject e4Parent = GameObject.FindGameObjectWithTag("Enemy4Parent");
        if (BOSS != null)
        {
            if (e4Parent == null)
            {
                Instantiate(EnemyParent, transform.position, transform.rotation);
            }
        }
    }
}