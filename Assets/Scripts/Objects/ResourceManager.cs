using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResourceManager : MonoBehaviour
{
    //Variable publicas

    public Text resourceText;

    //Variables privadas

    private float currentResources;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializar variables
        currentResources = 0f;
        UpdateUI();
    }

    //Funcion para agregar recursos
    public void AddResources(float _value)
    {
        currentResources += _value;
        UpdateUI();
    }

    //Funcion para quitaer recursos
    public void RemoveResources(float _value)
    {
        currentResources -= _value;
        UpdateUI();
    }

    //Funcion para devolcer los recursos actuales
    public float CurrentResources()
    {
        return currentResources;
    }

    //Funcion para actualizar el UI
    public void UpdateUI()
    {
        resourceText.text = "Feria UwU: $" + currentResources;
    }
}
