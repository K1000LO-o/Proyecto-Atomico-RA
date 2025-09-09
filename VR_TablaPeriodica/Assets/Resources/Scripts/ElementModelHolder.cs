using UnityEngine;

public class ElementModelHolder : MonoBehaviour
{
    public GameObject CurrentModel;
    public Transform ModelHolder;


    public void ChangeModel(GameObject newModel)
    {
        if (CurrentModel != null)
        {
            Destroy(CurrentModel);
        }

        // Instanciar como hijo del holder
        CurrentModel = Instantiate(newModel, ModelHolder);

        // Resetear posición, rotación y escala local
        CurrentModel.transform.localPosition = Vector3.zero;
        CurrentModel.transform.localRotation = Quaternion.identity;
    }
}
