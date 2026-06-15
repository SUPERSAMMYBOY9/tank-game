using UnityEngine;

[CreateAssetMenu(fileName = "bullets", menuName = "Scriptable Objects/bullets")]
public class bullets : ScriptableObject
{
    public string bulletName;
    public int bulletDamage;
    public float bulletSpeed;
    public float bulletLifetime;
    public Material bulletMatereal;
}
