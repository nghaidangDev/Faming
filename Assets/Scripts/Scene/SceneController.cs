using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Load_Level_01()
    {
        SceneManager.LoadScene("Level_01");
    }
}
