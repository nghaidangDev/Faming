using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldown : MonoBehaviour
{
    [SerializeField] private Image cooldownImage;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (cooldownImage != null && playerMovement != null)
        {
            // Cập nhật fillAmount dựa trên dashCoolCounter
            cooldownImage.fillAmount = 1;
        }
    }

}
