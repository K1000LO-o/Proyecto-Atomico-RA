using TMPro;
using UnityEngine;

public class AtomicUIManager : MonoBehaviour {
    public atomicLevel[] nivelesUI;
    public TMP_Text Configuracion;

    public void MostrarConfiguracion(string config)
    {
        Configuracion.text = "Configuracion:" + config;
        var parsed = ElectronConfigurationParser.ParseConfiguration(config);

        foreach (var nivelUI in nivelesUI)
        {
            if (parsed.TryGetValue(nivelUI.level, out int[] orbitals))
            {
                for (int i = 0; i < orbitals.Length; i++)
                {
                    nivelUI.espacioTexto(nivelUI.espacio[i], orbitals[i]);
                }
            }
            else
            {
                // Si ese nivel no existe en la configuración, lo pintamos vacío
                for (int i = 0; i < nivelUI.espacio.Length; i++)
                {
                    nivelUI.espacioTexto(nivelUI.espacio[i], 0);
                }
            }
        }
    }
}