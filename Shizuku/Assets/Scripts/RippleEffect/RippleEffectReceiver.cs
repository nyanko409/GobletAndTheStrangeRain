using UnityEngine;

public class RippleEffectReceiver : MonoBehaviour
{
    [ColorUsage(false, true)] public Color startColor;      // the starting color

    Material material;                                      // reference to the material
    int rippleCount;                                        // maximum active ripple count
    RippleData[] ripples;                                   // ripple data to pass to the shader
    Color backgroundColor;                                  // current background color of the mesh



    public RippleData[] GetRippleDatas()
    {
        return ripples;
    }

    public Color GetBackgroundColor()
    {
        return backgroundColor;
    }

    public void ApplyEffect(Vector3 contactPoint, Color rippleColor, float spreadSpeed)
    {
        // return if this object does not have a ripple receiver tag
        if (!GetComponent<Tag>().HasTag(TagType.RippleReceiver)) return;

        // activate the ripple effect if there is a free space
        for (int i = 0; i < rippleCount; ++i)
        {
            if (!ripples[i].isSpreading)
            {
                ripples[i].radius = 0;
                ripples[i].position = contactPoint;
                ripples[i].maxRadius = GetFarthestVertex(contactPoint);
                ripples[i].color = rippleColor;
                ripples[i].spreadSpeed = spreadSpeed;
                ripples[i].isSpreading = true;
                ripples[i].layer = GetNextLayer();

                break;
            }
        }
    }


    void Start()
    {
        material = GetComponent<Renderer>().material;

        // get the maximum ripple count from the shader and init the ripple layers
        rippleCount = material.GetInt("_maxRippleCount");
        ripples = new RippleData[rippleCount];
        for(int i = 0; i < rippleCount; ++i)
        {
            ripples[i].layer = i + 1;
        }

        // set the start color of the shader
        material.SetColor("_BaseColor", startColor);
        backgroundColor = startColor;
    }

    void Update()
    {
        // update every active ripple
        for (int i = 0; i < rippleCount; ++i)
        {
            if (ripples[i].isSpreading)
            {
                ripples[i].radius += ripples[i].spreadSpeed * Time.deltaTime;

                material.SetFloat("_RippleRadius" + ripples[i].layer, ripples[i].radius);
                material.SetVector("_RippleLocation" + ripples[i].layer, ripples[i].position);
                material.SetColor("_RippleColor" + ripples[i].layer, ripples[i].color);

                // ripple finished expanding through the whole mesh
                if (ripples[i].radius >= ripples[i].maxRadius)
                {
                    // set ripple radius forcefully to 0 to prevent overlapping
                    material.SetFloat("_RippleRadius" + ripples[i].layer, 0);
                    material.SetColor("_BaseColor", ripples[i].color);

                    ripples[i].layer = -1;
                    ripples[i].radius = -1;
                    ripples[i].maxRadius = -1;
                    ripples[i].isSpreading = false;
                    backgroundColor = ripples[i].color;
                }
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
            // ignore if active layer is 1 and prevent duplicate layers
            if (ripples[i].layer == 1 || (i >= 1 && ripples[i - 1].layer == (ripples[i].layer - 1)))
                continue;

            ripples[i].layer--;
        }

        return rippleCount;
    }
}
