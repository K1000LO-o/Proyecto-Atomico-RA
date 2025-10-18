using System.Collections.Generic;
using UnityEngine;

public class PeriodicTable : MonoBehaviour
{
    public ElementMaterials elementMaterials;
    public ElementData rotativeElementData;
    public Color colorus;
    public List<Transform> alcalinos;
    public List<Transform> alcalinosTerreos;
    public List<Transform> lantanidos;
    public List<Transform> actinidos;
    public List<Transform> metalesDeTransicion;
    public List<Transform> metalesDelBloqueP;
    public List<Transform> semimetales;
    public List<Transform> otrosNoMetales;
    public List<Transform> gasesNobles;
    public List<Transform> desconocidos;
    public List<CategoryHober> categories = new List<CategoryHober>();

    [Header("Tarjetas")]
    public Transform ElementInfo;
    public InformacionAtomo tarjetaInformacionAtomo;
    public ElementModelHolder elementModelHolder;
    public ElementData elementToShow;
    public ElectronConfiguration electronConfiguration;
    public AtomicUIManager atomicUIManager;


    private void Awake()
    {
        alcalinos = new List<Transform>();
        alcalinosTerreos = new List<Transform>();
        lantanidos = new List<Transform>();
        actinidos = new List<Transform>();
        metalesDeTransicion = new List<Transform>();
        metalesDelBloqueP = new List<Transform>();
        semimetales = new List<Transform>();
        otrosNoMetales = new List<Transform>();
        gasesNobles = new List<Transform>();
        desconocidos = new List<Transform>();
        updateAllColorsTransparency(0.95f);
    }

    void OnEnable()
    {
        updateAllColorsTransparency(0.95f);
    }

    void OnDisable()
    {
        
    }

    public void showElementInfo(ElementData elementToShow)
    {
        ElementInfo.gameObject.SetActive(true);
        tarjetaInformacionAtomo.gameObject.SetActive(true);
        tarjetaInformacionAtomo.setAtomicInfo(elementToShow);
        elementModelHolder.ChangeModel(elementToShow.elementModelPrefab);
        transform.gameObject.SetActive(false);

    }

    public void setCategorys(elementCategory choosedElementCategory, float transparency)
    {
        float commonTrasnparency = 0.95f;
        switch (choosedElementCategory)
        {
            case elementCategory.Alcalino:
                updateAllColorsTransparency(transparency);
                UpdateColorTransparency(elementMaterials.Alcalino, commonTrasnparency);
                break;

            case elementCategory.Alcalinoterreo:
                updateAllColorsTransparency(transparency);
                UpdateColorTransparency(elementMaterials.AlcalinoTerreo, commonTrasnparency);
                break;

            case elementCategory.Lantanido:
                updateAllColorsTransparency(transparency);
                UpdateColorTransparency(elementMaterials.Lantanido, commonTrasnparency);
                break;
            case elementCategory.Actinido:
                updateAllColorsTransparency(transparency);
                UpdateColorTransparency(elementMaterials.Actinido, commonTrasnparency);
                break;
            case elementCategory.MetalDeTransicion:
                updateAllColorsTransparency(transparency);
                UpdateColorTransparency(elementMaterials.MetalDeTransicion, commonTrasnparency);
                break;
            case elementCategory.MetalDelBloqueP:
                updateAllColorsTransparency(transparency);
                UpdateColorTransparency(elementMaterials.MetalDelBloqueP, commonTrasnparency);
                break;
            case elementCategory.Semimetal:
                updateAllColorsTransparency(transparency);
                UpdateColorTransparency(elementMaterials.Semimetal, commonTrasnparency);
                break;
            case elementCategory.OtrosNoMetales:
                updateAllColorsTransparency(transparency);
                UpdateColorTransparency(elementMaterials.OtrosNoMetales, commonTrasnparency);
                break;
            case elementCategory.GasesNobles:
                updateAllColorsTransparency(transparency);
                UpdateColorTransparency(elementMaterials.GasesNobles, commonTrasnparency);
                break;
            case elementCategory.Desconocido:
            updateAllColorsTransparency(transparency);
            UpdateColorTransparency(elementMaterials.Desconocidos, commonTrasnparency);
            break;
        }
    }

    public void updateAllColorsTransparency(float transparency)
    {
        Color alcalino = elementMaterials.Alcalino.color;
        alcalino.a = transparency;
        elementMaterials.Alcalino.color = alcalino;
        foreach (Transform item in alcalinos)
        {
            item.GetComponent<MeshRenderer>().sharedMaterial = elementMaterials.Alcalino;
        }

        Color alcalinoterreo = elementMaterials.AlcalinoTerreo.color;
        alcalinoterreo.a = transparency;
        elementMaterials.AlcalinoTerreo.color = alcalinoterreo;
        foreach (Transform item in alcalinosTerreos)
        {
            item.GetComponent<MeshRenderer>().sharedMaterial = elementMaterials.AlcalinoTerreo;
        }

        Color lantanido = elementMaterials.Lantanido.color;
        lantanido.a = transparency;
        elementMaterials.Lantanido.color = lantanido;
        foreach (Transform item in lantanidos)
        {
            item.GetComponent<MeshRenderer>().sharedMaterial = elementMaterials.Lantanido;
        }

        Color actinidio = elementMaterials.Actinido.color;
        actinidio.a = transparency;
        elementMaterials.Actinido.color = actinidio;
        foreach (Transform item in actinidos)
        {
            item.GetComponent<MeshRenderer>().sharedMaterial = elementMaterials.Actinido;
        }

        Color metaldetransicion = elementMaterials.MetalDeTransicion.color;
        metaldetransicion.a = transparency;
        elementMaterials.MetalDeTransicion.color = metaldetransicion;
        foreach (Transform item in metalesDeTransicion)
        {
            item.GetComponent<MeshRenderer>().sharedMaterial = elementMaterials.MetalDeTransicion;
        }

        Color metaldelbloquep = elementMaterials.MetalDelBloqueP.color;
        metaldelbloquep.a = transparency;
        elementMaterials.MetalDelBloqueP.color = metaldelbloquep;
        foreach (Transform item in metalesDelBloqueP)
        {
            item.GetComponent<MeshRenderer>().sharedMaterial = elementMaterials.MetalDelBloqueP;
        }

        Color semimetal = elementMaterials.Semimetal.color;
        semimetal.a = transparency;
        elementMaterials.Semimetal.color = semimetal;
        foreach (Transform item in semimetales)
        {
            item.GetComponent<MeshRenderer>().sharedMaterial = elementMaterials.Semimetal;
        }

        Color otrosnometales = elementMaterials.OtrosNoMetales.color;
        otrosnometales.a = transparency;
        elementMaterials.OtrosNoMetales.color = otrosnometales;
        foreach (Transform item in otrosNoMetales)
        {
            item.GetComponent<MeshRenderer>().sharedMaterial = elementMaterials.OtrosNoMetales;
        }

        Color gasesnobles = elementMaterials.GasesNobles.color;
        gasesnobles.a = transparency;
        elementMaterials.GasesNobles.color = gasesnobles;
        foreach (Transform item in gasesNobles)
        {
            item.GetComponent<MeshRenderer>().sharedMaterial = elementMaterials.GasesNobles;
        }

        Color desconocido = elementMaterials.Desconocidos.color;
        desconocido.a = transparency;
        elementMaterials.Desconocidos.color = desconocido;
        foreach (Transform item in desconocidos)
        {
            item.GetComponent<MeshRenderer>().sharedMaterial = elementMaterials.Desconocidos;
        }
    }
    public void UpdateColorTransparency(Material ChoosedElementMaterial, float transparency)
    {
        Color materialcolor = ChoosedElementMaterial.color;
        materialcolor.a = transparency;
        ChoosedElementMaterial.color = materialcolor;
    }


}
