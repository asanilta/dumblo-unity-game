﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SplashAnimation : MonoBehaviour {
	public GameObject[] prefabs;

	GameObject logo;
	GameObject dark;
	GameObject dark2;

	Image logoI;
	Image darkI;
	Image dark2I;

	static public int sequence = 0;
	//int ctr = 0;
	// Use this for initialization
	void Start () {
		dark = Instantiate(prefabs[1]) as GameObject;
		dark.transform.SetParent(GameObject.Find("Canvas").transform);
		dark.transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);
		dark.transform.localPosition = new Vector3 (0, 0, 0);
		logo = Instantiate(prefabs[0]) as GameObject;
		logo.transform.SetParent(GameObject.Find("Canvas").transform);
		logo.transform.localScale = new Vector3 (0.4f, 0.4f, 0.4f);
		logo.transform.localPosition = new Vector3 (0, 0, 0);
		dark2 = Instantiate(prefabs[1]) as GameObject;
		dark2.transform.SetParent(GameObject.Find("Canvas").transform);
		dark2.transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);
		dark2.transform.localPosition = new Vector3 (0, 0, 0);
		darkI = dark.GetComponent<Image>();
		Color c = darkI.color;
		c.a = 0;
		darkI.color = c;
		logoI = logo.GetComponent<Image>();
		c = logoI.color;
		c.a = 0;
		logoI.color = c;
		dark2I = dark2.GetComponent<Image>();
		c = dark2I.color;
		c.a = 0;
		dark2I.color = c;
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalData.new_player) {
			switch (sequence) {
			case 0:
				Animation1 ();
				break;
			case 1:
				Animation2 ();
				break;
			case 2:
				Animation3 ();
				break;
			case 3:
				break;
			case 4:
				Animation4 ();
				break;
			}
		} else {
			Destroy (dark);
			Destroy (dark2);
			Destroy (this);
		}
	}

	void Animation1() {
		if (darkI.color.a < 0.4) {
			Color c = darkI.color;
			c.a += 0.01f;
			darkI.color = c;
		} else
			sequence = 1;
	}

	void Animation2() {
		if (logoI.color.a < 1) {
			Color c = logoI.color;
			c.a += 0.01f;
			logoI.color = c;
		} else
			sequence = 2;
	}

	void Animation3() {
		if (dark2I.color.a < 0.8) {
			Color c = dark2I.color;
			c.a += 0.01f;
			dark2I.color = c;
		} else
			sequence = 3;
	}

	void Animation4() {
		if (logo.transform.position.y < 156)
			logo.transform.position += transform.up;
		else
			sequence = 5;
	}
}
