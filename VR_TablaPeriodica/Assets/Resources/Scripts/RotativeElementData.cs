using TMPro;
using UnityEngine;

public class RotativeElementData : MonoBehaviour
{
    public PeriodicTable periodicTable;
    public string elementName;
    public string elementSymbol;
    public int elementAtomicNumber;
    public float elementAverageAtomicMass;
    public elementCategory elementCategoryField;
    public string elementState;
    public string elementDensity;
    public string meltingPoint;
    public string boilingPoint;
    public int neutronCount;
    public int protonCount;
    public int electronCount;
    public int electronShells;
    public int[] electronsPerShell;

    public TextMeshPro textElementName;
    public TextMeshPro textElementSymbol;
    public TextMeshPro textAtomicNumber;
    public TextMeshPro textAverageAtomicMass;
    public Renderer elementRenderer;
}