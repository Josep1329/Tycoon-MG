using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{
    public ResourceManager resourceManager;
    public float cost;
    public string text;

    public UnityEvent EventoCanonico;

    private TextMesh textMesh;

    void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();

        textMesh.text = text + "$" + cost;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(resourceManager.CurrentResources() >= cost)
            {
                resourceManager.RemoveResources(cost);
                EventoCanonico.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
