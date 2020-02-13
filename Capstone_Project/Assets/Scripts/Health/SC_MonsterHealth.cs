using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MonsterHealth : MonoBehaviour
{
    private SC_Monster monster;

    public GameObject healthBar;


    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<SC_Monster>();

        monster.currentHealth = monster.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.localScale = new Vector3(monster.currentHealth / monster.maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.x);
    }
}
