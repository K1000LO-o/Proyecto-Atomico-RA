using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformacionAtomo : MonoBehaviour
{
    public Image image;
    public TMP_Text Nombre;
    public TMP_Text Simbolo;
    public TMP_Text NumeroAtomico;
    public TMP_Text AnoDeDescrubrimiento;
    public TMP_Text Descripcion;
    public bool isActive;

    public void setAtomicInfo(ElementData elementData)
    {
        image.sprite = elementData.elementImage;
        Nombre.text = "Nombre: " +elementData.elementName;
        Simbolo.text = "Simbolo: " + "''" + elementData.elementSymbol + "''";
        NumeroAtomico.text = "Numero Atomico: " + elementData.elementAtomicNumber;
        AnoDeDescrubrimiento.text = "Año De Descrubrimiento: "+ elementData.anoDescubrimiento;
        Descripcion.text = "Descripcion: " +elementData.elementDescription;
    }
    public void setAtomicInfo()
    {

    }
}
