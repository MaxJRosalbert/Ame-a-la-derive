using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauInteractionNiv1 : MonoBehaviour
{
    public GameObject dialogue1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoiteDialogueNiv()
    {
        Invoke("Dialogue1", 0.5f);
    }

    public void DialogueNiv()
    {
        dialogue1.SetActive(true);
    }
}
