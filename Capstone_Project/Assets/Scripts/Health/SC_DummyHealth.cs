using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DummyHealth : MonoBehaviour
{

    private SC_Dummy dummy;

    public GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        dummy = GetComponent<SC_Dummy>();

        dummy.currentHealth = dummy.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.localScale = new Vector3(dummy.currentHealth / dummy.maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.x);
    }
}
