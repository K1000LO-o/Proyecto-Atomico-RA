using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class VolverHover : MonoBehaviour {
    
    [SerializeField] private float scaleFactor = 1.2f;
    private Vector3 normalScale;
    [SerializeField] private float scaleDuration = 0.2f;
    [SerializeField] private bool onlyLeftHand = true; // puedes elegir si solo la izquierda activa hover
    public bool isHovered;
    private Vector3 originalScale;
    private Material hoverMaterial;
    private Material defaultMaterial;
    private Renderer objectRenderer;
    private MaterialPropertyBlock propertyBlock;
    public elementCategory categoryField;
    public PeriodicTable periodicTable;
    public Transform ElementInfo;

    void Awake()
    {
        normalScale = transform.localScale;
    }

    private void OnEnable()
    {
        transform.localScale = normalScale;
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            defaultMaterial = objectRenderer.material;
        }

        hoverMaterial = Resources.Load<Material>("Materials/HoverMaterial");
        propertyBlock = new MaterialPropertyBlock();

        originalScale = transform.localScale;

        // Suscribir eventos XR
        var interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);
        interactable.selectEntered.AddListener(OnSelectWhileHover);
    }

    private void OnDisable()
    {
        var interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.RemoveListener(OnHoverEnter);
        interactable.hoverExited.RemoveListener(OnHoverExit);
        interactable.selectEntered.RemoveListener(OnSelectWhileHover);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        // Ya no existe xrController -> ahora distinguimos por nombre o tag
        if (onlyLeftHand && !IsLeftHand(args.interactorObject)) return;

        StartCoroutine(ScaleObject(originalScale * scaleFactor, scaleDuration));
        isHovered = true;
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        if (onlyLeftHand && !IsLeftHand(args.interactorObject)) return;

        StartCoroutine(ScaleObject(originalScale, scaleDuration));
        isHovered = false;
    }

    private void OnSelectWhileHover(SelectEnterEventArgs args)
    {
        if (!isHovered) return; // solo si estaba en hover
        if (onlyLeftHand && !IsLeftHand(args.interactorObject)) return;

        selectElement();
    }

    private void selectElement()
    {
        Debug.Log("Categoria Seleccionada: " + categoryField);
        foreach (CategoryHober category in periodicTable.categories)
        {
            periodicTable.gameObject.SetActive(true);
            ElementInfo.gameObject.SetActive(false);
        }
        
        
        // 👉 aquí pones la lógica que quieras al hacer click/grab
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

    private bool IsLeftHand(IXRInteractor interactor)
    {
        if (interactor.transform.name.ToLower().Contains("left"))
            return true;

        if (interactor.transform.CompareTag("LeftHand"))
            return true;

        return false;
    }
}