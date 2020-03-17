using UnityEngine;

public class RippleEffectReceiver : MonoBehaviour
{
    Material material;          // reference to the material
    const int rippleCount = 3;  // maximum active ripple count

    // values for the shader to pass in
    Vector3[] ripplePosition;
    Color[] rippleColor;      
    float[] rippleSpreadSpeed;
    float[] rippleRadius;
    float[] maxRippleRadius;
    bool[] isSpreading;
    int[] rippleLayer;


    void Start()
    {
        material = GetComponent<Renderer>().material;

        ripplePosition = new Vector3[rippleCount];
        rippleColor = new Color[rippleCount];
        rippleSpreadSpeed = new float[rippleCount];
        rippleRadius = new float[rippleCount];
        maxRippleRadius = new float[rippleCount];
        isSpreading = new bool[rippleCount];
        rippleLayer = new int[rippleCount];
    }

    void Update()
    {
        // update every active ripple
        for (int i = 0; i < rippleCount; ++i)
        {
            if (isSpreading[i])
            {
                rippleRadius[i] += rippleSpreadSpeed[i] * Time.deltaTime;

                material.SetFloat("_RippleRadius" + rippleLayer[i], rippleRadius[i]);
                material.SetVector("_RippleLocation" + rippleLayer[i], ripplePosition[i]);
                material.SetColor("_RippleColor" + rippleLayer[i], rippleColor[i]);

                // ripple finished expanding through the whole mesh
                if (rippleRadius[i] >= maxRippleRadius[i])
                {
                    // set ripple radius forcefully to 0 to prevent overlapping
                    material.SetFloat("_RippleRadius" + rippleLayer[i], 0);
                    material.SetColor("_BackgroundColor", rippleColor[i]);

                    rippleLayer[i] = -1;
                    isSpreading[i] = false;
                }
            }
        }
    }

    public void ApplyEffect(Vector3 contactPoint, Color rippleColor, float spreadSpeed)
    {
        // activate the ripple effect if there is a free space
        for(int i = 0; i < rippleCount; ++i)
        {
            if(!isSpreading[i])
            {
                rippleRadius[i] = 0;
                ripplePosition[i] = contactPoint;
                maxRippleRadius[i] = GetFarthestVertex(contactPoint);
                this.rippleColor[i] = rippleColor;
                rippleSpreadSpeed[i] = spreadSpeed;
                isSpreading[i] = true;
                rippleLayer[i] = GetNextLayer();
                break;
            }
        }
    }
    
    float GetFarthestVertex(Vector3 origin)
    {
        // get every vertex from mesh (enable read/write in mesh settings!)
        Vector3[] vertices = GetComponent<MeshFilter>().sharedMesh.vertices;

        // get the local to world transformation matrix
        Matrix4x4 localToWorld = transform.localToWorldMatrix;

        // offset each vertex to world position and
        // calculate the distance between contact point and vertex position
        float[] dist = new float[vertices.Length];
        for(int i = 0; i < vertices.Length; ++i)
        {
            vertices[i] = localToWorld.MultiplyPoint3x4(vertices[i]);
            dist[i] = Mathf.Abs(Vector3.Distance(vertices[i], origin));
        }

        // sort the array and return the farthest vertex position
        System.Array.Sort(dist);
        return dist[dist.Length - 1];
    }

    int GetNextLayer()
    {
        for(int i = 0; i < rippleCount; ++i)
        {
            rippleLayer[i]--;
        }

        return rippleCount;
    }
}
