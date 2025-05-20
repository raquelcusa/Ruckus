// ObjetoInteractivo.cs
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjetoInteractivo : MonoBehaviour
{
    [HideInInspector] public SpawnerManager manager;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool fueLanzado = false;

    void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grabInteractable == null)
            Debug.LogError("Falta XRGrabInteractable en el prefab.");
    }

    void OnEnable()
    {
        grabInteractable.selectExited.AddListener(OnSoltado);
    }

    void OnDisable()
    {
        grabInteractable.selectExited.RemoveListener(OnSoltado);
    }

    private void OnSoltado(SelectExitEventArgs args)
    {
        if (!fueLanzado)
        {
            fueLanzado = true;
            manager.ObjetoRecogido(gameObject);
            Destroy(gameObject, 0.1f);
        }
    }
}
