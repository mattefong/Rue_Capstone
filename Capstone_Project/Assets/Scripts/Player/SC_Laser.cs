using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Laser : MonoBehaviour
{
    public bool ready = false;
    public float downTime, upTime, pressTime = 0;
    public float countDown = 1.0f;
    public Image bombBar;

    public GameObject projectile;
    public Transform firePosition;

    public float timeBtwShots;
    public float startTimeBtwShots;

    private SC_PlayerMovement PC;

    private void Update()
    {
        ShootLaser();
    }

    private void ShootLaser()
    {
        //Fireball
        if (Input.GetButtonDown("Fire2") && ready == false)
        {
            //PS.DecreaseMana(5f);
            downTime = Time.time;
            pressTime = downTime + countDown;
            if (pressTime <= countDown)
                pressTime += Time.deltaTime;
            ready = true;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            ready = false;
        }

        if (Time.time >= pressTime && ready == true)
        {
            GameObject g = Instantiate(projectile, firePosition.position, transform.rotation);
            g.GetComponent<SC_Projectile>().direction = PC.GetFacingDirection();
            timeBtwShots = startTimeBtwShots;
        }

        if (ready)
        {
            bombBar.fillAmount = Time.time - downTime / countDown;
        }
        else
        {
            bombBar.fillAmount = 0;
        }
    }
}
