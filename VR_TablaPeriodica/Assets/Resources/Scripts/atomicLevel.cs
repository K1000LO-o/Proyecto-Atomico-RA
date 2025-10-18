using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class atomicLevel : MonoBehaviour
{
    public string level;
    public int number;
    public Transform[] espacio;

    public void espacioTexto(Transform espacioToFind, int textoValor)
    {
        espacioToFind.GetComponentInChildren<TMP_Text>().text = textoValor.ToString();
        switch (textoValor)
        {
            case 0:
                espacioColor(espacioToFind, Color.white);
                break;
            case 1:
                espacioColor(espacioToFind, Color.blue);
                break;
            case 2:
                espacioColor(espacioToFind, Color.green);
                break;
                
        }
    }
    public void espacioColor(Transform espacioTochange, Color color)
    {
        color.a = 0.4f;
        espacioTochange.transform.GetComponent<Image>().color = color;
    }
}