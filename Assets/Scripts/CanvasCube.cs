using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasCube : MonoBehaviour
{
    private int index = 0;
    public TextMeshProUGUI textMesh;

    private void Awake()
    {
        textMesh = transform.GetComponentInChildren<TextMeshProUGUI>();
        Generator.Instance.gencubes.Add(this.gameObject);
        index = Generator.Instance.gencubes.Count-1;
        textMesh.text = index.ToString();
    }
}
