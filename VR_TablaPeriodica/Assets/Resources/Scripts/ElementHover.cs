using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRBaseInteractable))]
public class ElementHover : MonoBehaviour
{
    [SerializeField] private float scaleFactor = 1.2f;
    [SerializeField] private float scaleDuration = 0.2f;
    [SerializeField] private bool onlyLeftHand = true;
    public bool isHovered;

    private Vector3 originalScale;
    private Material hoverMaterial;
    private Material defaultMaterial;
    private Renderer objectRenderer;
    private MaterialPropertyBlock propertyBlock;
    public ElementData elementData;
    void Awake()
    {
        originalScale = transform.localScale;       
    }

    private void OnEnable()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            defaultMaterial = objectRenderer.material;
        }

        hoverMaterial = Resources.Load<Material>("Materials/HoverMaterial");
        propertyBlock = new MaterialPropertyBlock();

        StartCoroutine(ScaleObject(originalScale, 0.0001f));

        // Suscribir eventos XR
        var interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);
        interactable.selectEntered.AddListener(OnSelectWhileHover);
    }

    private void OnDisable()
    {
        StartCoroutine(ScaleObject(originalScale, 0.0001f));
        var interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.RemoveListener(OnHoverEnter);
        interactable.hoverExited.RemoveListener(OnHoverExit);
        interactable.selectEntered.RemoveListener(OnSelectWhileHover);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (onlyLeftHand && !IsLeftHand(args.interactorObject)) return;

        SetMaterial(hoverMaterial);
        StartCoroutine(ScaleObject(originalScale * scaleFactor, scaleDuration));
        elementData.periodicTable.rotativeElementData.elementName = elementData.elementName;
        elementData.periodicTable.rotativeElementData.elementSymbol = elementData.elementSymbol;
        elementData.periodicTable.rotativeElementData.elementAtomicNumber = elementData.elementAtomicNumber;
        elementData.periodicTable.rotativeElementData.elementAverageAtomicMass = elementData.elementAverageAtomicMass;
        elementData.periodicTable.rotativeElementData.elementCategoryField = elementData.elementCategoryField;
        elementData.periodicTable.rotativeElementData.UpdateElementData();
        isHovered = true;

    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        if (onlyLeftHand && !IsLeftHand(args.interactorObject)) return;

        SetMaterial(defaultMaterial);
        StartCoroutine(ScaleObject(originalScale, scaleDuration));
        elementData.periodicTable.rotativeElementData.elementName = "Vacio";
        elementData.periodicTable.rotativeElementData.elementSymbol = "Va";
        elementData.periodicTable.rotativeElementData.elementAtomicNumber = 0;
        elementData.periodicTable.rotativeElementData.elementAverageAtomicMass = 0;
        elementData.periodicTable.rotativeElementData.elementCategoryField = elementCategory.Default;
        elementData.periodicTable.rotativeElementData.UpdateElementData();
        isHovered = false;
    }

    private void OnSelectWhileHover(SelectEnterEventArgs args)
    {
        if (!isHovered) return;
        if (onlyLeftHand && !IsLeftHand(args.interactorObject)) return;


        selectElement();
    }

    private void selectElement()
    {
        Debug.Log("Elemento seleccionado: " + elementData.elementName);
        
        string atomicConfigurationElectronic = CalculateElectronicConfiguration(elementData);
        CalculateElectronConfigurationParser(atomicConfigurationElectronic);
        elementData.periodicTable.atomicUIManager.MostrarConfiguracion(atomicConfigurationElectronic);
        elementData.periodicTable.showElementInfo(elementData);

    }

    private IEnumerator ScaleObject(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }

    private void SetMaterial(Material material)
    {
        if (objectRenderer == null || material == null) return;

        objectRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetColor("_Color", material.color);
        objectRenderer.SetPropertyBlock(propertyBlock);
    }
    private bool IsLeftHand(IXRInteractor interactor)
    {
        if (interactor.transform.name.ToLower().Contains("left"))
            return true;

        if (interactor.transform.CompareTag("LeftHand"))
            return true;

        return false;
    }

    string CalculateElectronicConfiguration(ElementData element)
    {
        string config = ElectronConfiguration.GetElectronConfiguration(element);
        int[] shells = ElectronConfiguration.GetElectronsPerShell(element);

        Debug.Log("Configuración electrónica de " + element.elementName + ": " + config);

        string shellText = "";
        foreach (int e in shells) shellText += e + " ";
        Debug.Log("Electrones por nivel: " + shellText);
        return config;
    }

    public void CalculateElectronConfigurationParser(string config)
    {

        var parsed = ElectronConfigurationParser.ParseConfiguration(config);

        foreach (var kvp in parsed)
        {
            Debug.Log(kvp.Key + " → [" + string.Join(",", kvp.Value) + "]");
        }
    }
}
