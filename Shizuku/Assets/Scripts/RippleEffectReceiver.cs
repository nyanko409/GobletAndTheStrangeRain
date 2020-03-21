using UnityEngine;

public class RippleEffectReceiver : MonoBehaviour
{
    Material material;          // reference to the material
    const int rippleCount = 3;  // maximum active ripple count

    RippleData[] ripples;       // ripple data to pass to the shader
    

    void Start()
    {
        material = GetComponent<Renderer>().material;

        ripples = new RippleData[rippleCount];
    }

    void Update()
    {
        // update every active ripple
        for (int i = 0; i < rippleCount; ++i)
        {
            if (ripples[i].isSpreading)
            {
                ripples[i].rippleRadius += ripples[i].rippleSpreadSpeed * Time.deltaTime;

                material.SetFloat("_RippleRadius" + ripples[i].rippleLayer, ripples[i].rippleRadius);
                material.SetVector("_RippleLocation" + ripples[i].rippleLayer, ripples[i].ripplePosition);
                material.SetColor("_RippleColor" + ripples[i].rippleLayer, ripples[i].rippleColor);

                // ripple finished expanding through the whole mesh
                if (ripples[i].rippleRadius >= ripples[i].maxRippleRadius)
                {
                    // set ripple radius forcefully to 0 to prevent overlapping
                    material.SetFloat("_RippleRadius" + ripples[i].rippleLayer, 0);
                    material.SetColor("_BackgroundColor", ripples[i].rippleColor);

                    ripples[i].rippleLayer = -1;
                    ripples[i].isSpreading = false;
                }
            }
        }
    }

    public void ApplyEffect(Vector3 contactPoint, Color rippleColor, float spreadSpeed)
    {
        // activate the ripple effect if there is a free space
        for(int i = 0; i < rippleCount; ++i)
        {
            if(!ripples[i].isSpreading)
            {
                ripples[i].rippleRadius = 0;
                ripples[i].ripplePosition = contactPoint;
                ripples[i].maxRippleRadius = GetFarthestVertex(contactPoint);
                ripples[i].rippleColor = rippleColor;
                ripples[i].rippleSpreadSpeed = spreadSpeed;
                ripples[i].isSpreading = true;
                ripples[i].rippleLayer = GetNextLayer();
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
            ripples[i].rippleLayer--;
        }

        return rippleCount;
    }
}
