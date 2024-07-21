using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject levelPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                levelPanel.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Collider đã bị hủy hoặc chưa được gán.");
        }

    }

    public void Exit_Load_Level_01()
    {
        levelPanel.SetActive(false);
    }
}
