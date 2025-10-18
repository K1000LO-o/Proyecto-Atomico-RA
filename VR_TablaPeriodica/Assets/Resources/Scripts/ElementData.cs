using TMPro;
using UnityEngine;

public enum elementCategory
{
    Alcalino,
    Alcalinoterreo,
    Lantanido,
    Actinido,
    MetalDeTransicion,
    MetalDelBloqueP,
    Semimetal,
    OtrosNoMetales,
    GasesNobles,
    Desconocido,
    Default
}
[ExecuteAlways]
public class ElementData : MonoBehaviour
{
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
    public int anoDescubrimiento;
    public string elementDescription;
    public Sprite elementImage;
    public GameObject elementModelPrefab;
    public float elementModelPrefabScale;

    public TextMeshPro textElementName;
    public TextMeshPro textElementSymbol;
    public TextMeshPro textAtomicNumber;
    public TextMeshPro textAverageAtomicMass;
    public Renderer elementRenderer;
    public PeriodicTable periodicTable;
    public Material ElementMaterial;

    void Awake()
    {
        elementRenderer = GetComponent<MeshRenderer>();
        if (elementCategoryField == elementCategory.Alcalino)
        {
            periodicTable.alcalinos.Add(transform);
        }
        else if (elementCategoryField == elementCategory.Alcalinoterreo)
        {
            periodicTable.alcalinosTerreos.Add(transform);
        }
        else if (elementCategoryField == elementCategory.Lantanido)
        {
            periodicTable.lantanidos.Add(transform);
        }
        else if (elementCategoryField == elementCategory.Actinido)
        {
            periodicTable.actinidos.Add(transform);
        }
        else if (elementCategoryField == elementCategory.MetalDeTransicion)
        {
            periodicTable.metalesDeTransicion.Add(transform);
        }
        else if (elementCategoryField == elementCategory.MetalDelBloqueP)
        {
            periodicTable.metalesDelBloqueP.Add(transform);
        }
        else if (elementCategoryField == elementCategory.Semimetal)
        {
            periodicTable.semimetales.Add(transform);
        }
        else if (elementCategoryField == elementCategory.OtrosNoMetales)
        {
            periodicTable.otrosNoMetales.Add(transform);
        }
        else if (elementCategoryField == elementCategory.GasesNobles)
        {
            periodicTable.gasesNobles.Add(transform);
        }
        else if (elementCategoryField == elementCategory.Desconocido)
        {
            periodicTable.desconocidos.Add(transform);
        }
        UpdateElementData();
        electronCount = elementAtomicNumber;
    }

    void OnEnable()
    {
        UpdateElementData();
        electronCount = elementAtomicNumber;
    }
    public void UpdateElementData()
    {
        textElementName.text = elementName;
        textElementSymbol.text = elementSymbol;
        textAtomicNumber.text = elementAtomicNumber.ToString();
        textAverageAtomicMass.text = elementAverageAtomicMass.ToString();
        gameObject.name = elementAtomicNumber.ToString() + " " + elementName;
        SetElementMaterial(elementCategoryField);
    }

    public void SetElementMaterial(elementCategory category)
    {
        switch (category)
        {
            case elementCategory.Alcalino:
                elementRenderer.sharedMaterial = periodicTable.elementMaterials.Alcalino;
                break;
            case elementCategory.Alcalinoterreo:
                elementRenderer.sharedMaterial = periodicTable.elementMaterials.AlcalinoTerreo;
                break;
            case elementCategory.Lantanido:
                elementRenderer.sharedMaterial = periodicTable.elementMaterials.Lantanido;
                break;
            case elementCategory.Actinido:
                elementRenderer.sharedMaterial = periodicTable.elementMaterials.Actinido;
                break;
            case elementCategory.MetalDeTransicion:
                elementRenderer.sharedMaterial = periodicTable.elementMaterials.MetalDeTransicion;
                break;
            case elementCategory.MetalDelBloqueP:
                elementRenderer.sharedMaterial = periodicTable.elementMaterials.MetalDelBloqueP;
                break;
            case elementCategory.Semimetal:
                elementRenderer.sharedMaterial = periodicTable.elementMaterials.Semimetal;
                break;
            case elementCategory.OtrosNoMetales:
                elementRenderer.sharedMaterial = periodicTable.elementMaterials.OtrosNoMetales;
                break;
            case elementCategory.GasesNobles:
                elementRenderer.sharedMaterial = periodicTable.elementMaterials.GasesNobles;
                break;
            case elementCategory.Desconocido:
                elementRenderer.sharedMaterial = periodicTable.elementMaterials.Desconocidos;
                break;
            case elementCategory.Default:
                elementRenderer.sharedMaterial = periodicTable.elementMaterials.Default;
                break;
        }
    }


}
