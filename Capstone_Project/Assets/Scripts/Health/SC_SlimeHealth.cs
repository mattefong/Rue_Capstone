using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SlimeHealth : MonoBehaviour
{
    private SC_Slime slime;

    public GameObject healthBar;


    // Start is called before the first frame update
    void Start()
    {
        slime = GetComponent<SC_Slime>();

        slime.currentHealth = slime.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.localScale = new Vector3(slime.currentHealth / slime.maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.x);
    }
}
