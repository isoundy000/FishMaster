﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAttr : MonoBehaviour {
    [SerializeField]
    private float hp;
    [SerializeField]
    private int exp;
    [SerializeField]
    private int Gold;
    [SerializeField]
    private GameObject diePrefab;
    public int maxNum;
    public int maxSpeed;
    
    public float fishGenWaitTiem = 0.5f;//每条鱼生产的间隔

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Border")
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float value)
    {
        hp -= value;
        if (hp<=0)
        {
            GameObject die = Instantiate(diePrefab);
            die.transform.SetParent(transform.parent, false);
            die.transform.position = transform.position;
            die.transform.rotation = transform.rotation;
            Destroy(gameObject);
            GameController.instance.AddExpAndGold(exp, Gold);
            Destroy(die, 0.5f);
        }
    }
}
