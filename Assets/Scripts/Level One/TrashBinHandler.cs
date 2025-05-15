using UnityEngine;

public class TrashBinHandler : MonoBehaviour
{
    public TrashType acceptedType;
}

public enum TrashType
{
    Plastic,
    Glass,
    Paper,
    Metal,
    Organic,
    NonRecyclable
}
