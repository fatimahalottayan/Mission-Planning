using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    [SerializeField] GameObject Holder;
    List<GameObject> Units = new List<GameObject>();
   
    private void Awake()
    {
        if (Instance == null)
        {
           Instance = this;
        }
        else
        {
           Destroy(Instance);
        }
    }
    public void GenerateUnit(GameObject Unit)
    {
        GameObject obj = Instantiate(Unit,Holder.transform);
        Units.Add(obj);

    }
    public void DeleteUnit(GameObject Unit)
    {
        Units.Remove(Unit);
        Destroy(Unit);
    }
}
