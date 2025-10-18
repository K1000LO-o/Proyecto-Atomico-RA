using UnityEngine;

public class ElementAnimation : MonoBehaviour
{
    public Transform[] Neutrones;
    public Transform[] Protones;
    public Transform[] Orbitas;
    public float orbitaVelocity;
    public float ringAngleVelocityA;
    public float ringAngleVelocityB;

    private void Update()
    {
        for (int i = 0; i < Orbitas.Length; i++)
        {
            // calcular la rotación incremental
            Quaternion extraRotation = Quaternion.Euler(
                ringAngleVelocityA/(i+1)*Time.deltaTime,
                (orbitaVelocity / (i + 1)) * Time.deltaTime,
                ringAngleVelocityB /(i+1)*Time.deltaTime);

            // aplicarla multiplicando con la actual
            Orbitas[i].rotation = Orbitas[i].rotation * extraRotation;
        }
    }
}
