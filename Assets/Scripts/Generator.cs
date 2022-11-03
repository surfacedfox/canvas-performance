using System.Collections;
using System.Collections.Generic;
using Tayx.Graphy.Audio;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public static Generator Instance { get; private set; }

    [SerializeField]
    private GameObject canvasCubePrefab;
    [SerializeField]
    private GameObject textCubePrefab;
    [SerializeField]
    private GameObject textObject;
    [SerializeField]
    private Transform canvasTransform;

    [SerializeField]
    private int rows;
    [SerializeField]
    private int columns;
    [SerializeField]
    private int depth;
    [SerializeField]
    private float padding;

    private bool rendering = true;

    private Transform mainCam;

    public List<GameObject> gencubes;
    public List<GameObject> genText;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        mainCam = Camera.main.transform;
    }

    // Use this for initialization
    public void GenerateCanvasCubes()
    {
        Purge();
        for (int i = 0; i < depth; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                for (int k = 0; k < rows; k++)
                {
                    Vector3 pos = new Vector3(k * padding, j * padding, i * padding);
                    //print(pos);
                    GameObject foo = Instantiate(canvasCubePrefab, pos, Quaternion.identity);
                }
            }
        }
    }

    public void GenerateTextCubes()
    {
        Purge();
        for (int i = 0; i < depth; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                for (int k = 0; k < rows; k++)
                {
                    Vector3 pos = new Vector3(k * padding, j * padding, i * padding);
                    //print(pos);
                    GameObject foo = Instantiate(textCubePrefab, pos, Quaternion.identity);
                    GameObject bar = Instantiate(textObject, canvasTransform);
                }
            }
        }
    }

    public void Purge()
    {
        if (gencubes != null)
        {
            foreach (GameObject instance in gencubes)
            {
                Destroy(instance);
            }
        }
        gencubes.Clear();
    }

    public void ToggleRendering()
    {
        if(rendering)
        {
            if (gencubes != null)
            {
                foreach (GameObject instance in gencubes)
                {
                    instance.GetComponent<MeshRenderer>().enabled = false;
                }
                rendering = false;
            }
        }
        else
        {
            if (gencubes != null)
            {
                foreach (GameObject instance in gencubes)
                {
                    instance.GetComponent<MeshRenderer>().enabled = true;
                }
                rendering = true;
            }
        }
    }

    private void LateUpdate()
    {
        if(gencubes != null)
        {
            foreach(GameObject instance in gencubes)
            {
                instance.GetComponent<CanvasCube>().textMesh.transform.LookAt(mainCam.position * -1);
            }
        }
    }
}
