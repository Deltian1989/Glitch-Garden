using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    DefenderSpawner defenderSpawner;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    private void OnMouseDown()
    {
        var allButtons = FindObjectsOfType<DefenderButton>();

        foreach (var button in allButtons)
        {

            button.GetComponent<SpriteRenderer>().color = new Color32(58, 58, 58, 255);
        }

        // black 58 58 58
        spriteRenderer.color = new Color(255, 255, 255);

        defenderSpawner.SetSelectedDefender(defenderPrefab);


    }
}
