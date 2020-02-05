using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npc : MonoBehaviour
{
  [SerializeField]
  private Text interact;
  [SerializeField]
  private Text dialogue;

  [SerializeField]
  private Text dialogue2;
  [SerializeField]
  private Text dialogue3;

  public float timeLeft;
  private bool active = false;
  void Start()
  {
    interact.gameObject.SetActive(false);
    dialogue.gameObject.SetActive(false);
    dialogue2.gameObject.SetActive(false);
    dialogue3.gameObject.SetActive(false);
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.E))
    {
      interact.gameObject.SetActive(false);
      dialogue.gameObject.SetActive(true);
      timeLeft = 5;
      active = true;
    }

    if (active)
    {
      timeLeft -= Time.deltaTime;
      interact.gameObject.SetActive(false);
      if (timeLeft <= 0)
      {
        dialogue.gameObject.SetActive(false);
        dialogue2.gameObject.SetActive(true);
        if (timeLeft <= -5)
        {
          dialogue2.gameObject.SetActive(false);
          dialogue3.gameObject.SetActive(true);
          if (timeLeft <= -10)
          {
            dialogue3.gameObject.SetActive(false);
          }
        }
        //interact.gameObject.SetActive(true);

      }

    }

  }

  private void OnTriggerExit2D()
  {
    interact.gameObject.SetActive(false);
  }
  void OnTriggerEnter2D()
  {
    interact.gameObject.SetActive(true);
  }

}
