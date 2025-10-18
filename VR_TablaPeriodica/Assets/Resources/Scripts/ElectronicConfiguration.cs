using System;
using System.Collections.Generic;
using UnityEngine;

public class ElectronConfiguration
{

    private static readonly Dictionary<string, int> sublevelCapacities = new Dictionary<string, int>
    {
        { "1s", 2 },
        { "2s", 2 }, { "2p", 6 },
        { "3s", 2 }, { "3p", 6 }, { "3d", 10 },
        { "4s", 2 }, { "4p", 6 }, { "4d", 10 }, { "4f", 14 },
        { "5s", 2 }, { "5p", 6 }, { "5d", 10 }, { "5f", 14 },
        { "6s", 2 }, { "6p", 6 }, { "6d", 10 },
        { "7s", 2 }, { "7p", 6 }

    };


    private static readonly string[] fillingOrder = new string[]
    {
        "1s",
        "2s", "2p",
        "3s", "3p",
        "4s", "3d", "4p",
        "5s", "4d", "5p",
        "6s", "4f", "5d", "6p",
        "7s", "5f", "6d", "7p"
    };


    public static string GetElectronConfiguration(ElementData element)
    {
        int remainingElectrons = element.electronCount;
        string config = "";

        foreach (string orbital in fillingOrder)
        {
            if (remainingElectrons <= 0)
                break;

            int maxElectrons = sublevelCapacities[orbital];
            int electronsInOrbital = Mathf.Min(remainingElectrons, maxElectrons);

            config += orbital + electronsInOrbital + " ";
            remainingElectrons -= electronsInOrbital;
        }

        return config.Trim();
    }


    public static int[] GetElectronsPerShell(ElementData element)
    {
        int remainingElectrons = element.electronCount;
        Dictionary<int, int> shells = new Dictionary<int, int>();

        foreach (string orbital in fillingOrder)
        {
            if (remainingElectrons <= 0)
                break;

            int n = int.Parse(orbital.Substring(0, 1)); // nivel principal (1–7)
            int maxElectrons = sublevelCapacities[orbital];
            int electronsInOrbital = Mathf.Min(remainingElectrons, maxElectrons);

            if (!shells.ContainsKey(n))
                shells[n] = 0;

            shells[n] += electronsInOrbital;
            remainingElectrons -= electronsInOrbital;
        }

        // Convertimos a array (del nivel 1 hasta el más alto ocupado)
        int maxShell = 0;
        foreach (var key in shells.Keys)
            if (key > maxShell) maxShell = key;

        int[] electronsPerShell = new int[maxShell];
        for (int i = 1; i <= maxShell; i++)
        {
            electronsPerShell[i - 1] = shells.ContainsKey(i) ? shells[i] : 0;
        }

        return electronsPerShell;
    }
}
