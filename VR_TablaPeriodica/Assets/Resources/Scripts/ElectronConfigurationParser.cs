using System;
using System.Collections.Generic;

public class ElectronConfigurationParser
{
    // Máximox de orbitales por subnivel
    private static readonly Dictionary<char, int> orbitalCount = new Dictionary<char, int>
    {
        { 's', 1 },
        { 'p', 3 },
        { 'd', 5 },
        { 'f', 7 }
    };

    /// <summary>
    /// Convierte una configuración tipo 1s2 2s2 2p3 en un diccionario de niveles con sus orbitales.
    /// </summary>
    public static Dictionary<string, int[]> ParseConfiguration(string config)
    {
        var result = new Dictionary<string, int[]>();

        string[] parts = config.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string part in parts)
        {
            int level = int.Parse(part.Substring(0, 1));
            char sublevel = part[1];                      
            int electrons = int.Parse(part.Substring(2)); 

            int orbitalSlots = orbitalCount[sublevel];
            int[] orbitals = new int[orbitalSlots];
            int remaining = electrons;
            int index = 0;

            while (remaining > 0)
            {
                orbitals[index]++;
                remaining--;
                index = (index + 1) % orbitalSlots;
            }

            result[level + sublevel.ToString()] = orbitals;
        }

        return result;
    }
}
