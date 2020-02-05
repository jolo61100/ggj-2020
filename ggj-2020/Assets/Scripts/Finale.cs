using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finale : MonoBehaviour
{

  void OnTriggerStay2D()
  {
    SceneManager.LoadScene(5);
  }
}
