using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCClickHandler : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;

    //Panel màn chơi
    public GameObject levelPanel;
    public GameObject loadLevelPanel;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerIsClose)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OnNPCClicked();
            }
        }
    }

    private void OnNPCClicked()
    {
        if (dialoguePanel.activeInHierarchy)
        {
            zeroText();
        }
        else
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if(index < dialogue.Length - 1) 
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
            levelPanel.SetActive(true);
        }
    }

    public void Start_LoadLevel()
    {
        loadLevelPanel.SetActive(true);
    }

    public void Exit_LoadLevel()
    {
        levelPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }


}
