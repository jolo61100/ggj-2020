using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{

  public int sceneNum;
  public GameObject playerObject;


  public Vector3 spawnPos;

  private void Awake()
  {
    playerObject = FindObjectOfType<player>().gameObject;

  }

  void OnTriggerStay2D()
  {


    SceneManager.LoadScene(sceneNum);
    playerObject.transform.position = spawnPos;


  }
}