using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SkeletonHealth : MonoBehaviour
{
    private SC_Skeleton skeleton;

    public GameObject healthBar;


    // Start is called before the first frame update
    void Start()
    {
        skeleton = GetComponent<SC_Skeleton>();

        skeleton.currentHealth = skeleton.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.localScale = new Vector3(skeleton.currentHealth / skeleton.maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.x);
    }
}
