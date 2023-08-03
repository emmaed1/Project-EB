using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canva;
    bool PlayerDetection = false;

     void Update()
    {
        if (PlayerDetection)
        {
            canva.SetActive(true);
            print("Start Dialogue");
            NewDialogue("Hey! if you hold 'spacebar' down longer, you'll jump further!");
            canva.transform.GetChild(1).gameObject.SetActive(true);
            new WaitForSeconds(10);
            canva.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    void NewDialogue(string text)
    {
        GameObject template = Instantiate(d_template, d_template.transform);
        template.transform.parent = canva.transform;
        template.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            PlayerDetection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerDetection = false;
    }
}
