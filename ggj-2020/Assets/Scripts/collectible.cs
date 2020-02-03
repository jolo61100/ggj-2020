﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectible : MonoBehaviour
{

  [SerializeField]
  private Text pickingUp;

  [SerializeField]
  private Text TextBubble;

  public float timeLeft;
  private bool pickedUp;
  private bool isPickUp;

  //public GameObject itemPickUp;
  //public SpriteRenderer makeInvis;


  // Start is called before the first frame update
  private void Start()
  {
    makeEverythingFalse();
  }

  // Update is called once per frame
  private void Update()
  {
    if (isPickUp && Input.GetKeyDown(KeyCode.E))
    {
      getObject();
      pickedUp = true;
      DestroyObject();

    }

    if (pickedUp)
    {
      timeLeft -= Time.deltaTime;

      if (timeLeft <= 0)
      {
        TextBubble.gameObject.SetActive(false);
        timeLeft = 0;

      }
    }

  }

  private void makeEverythingFalse()
  {
    pickingUp.gameObject.SetActive(false);
    TextBubble.gameObject.SetActive(false);
    // itemPickUp.SetActive(false);
    pickedUp = false;
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.name.Equals("Player"))
    {
      pickingUp.gameObject.SetActive(true);
      isPickUp = true;

    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.name.Equals("Player"))
    {
      pickingUp.gameObject.SetActive(false);
      isPickUp = false;

    }



  }
  void getObject()
  {

    TextBubble.gameObject.SetActive(true);

    //  itemPickUp.SetActive(true);
  }

  void DestroyObject()
  {
    Destroy(this);
  }
}