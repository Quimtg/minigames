﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverGun : MonoBehaviour {

    public Image shootVFX;
    public AudioSource shootSFX;
    Animator shootAnimator;

	// Use this for initialization
	void Start () {
        shootVFX = GetComponent<Image>();
        shootSFX = GetComponent<AudioSource>();

        shootAnimator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(shoot());
	}

    public IEnumerator shoot()
    {
        //shootVFX.enabled = true;
        shootSFX.Play();
        shootAnimator.SetBool("Shoot", true);
        yield return new WaitForSecondsRealtime(0.05f);
        shootAnimator.SetBool("Shoot", false);
        yield return new WaitForSecondsRealtime(2f);
        //shootVFX.enabled = false;
    }

}
