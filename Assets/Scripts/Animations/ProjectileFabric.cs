using UnityEngine;

public class ProjectileFabric : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject projectile_mortire;
    

    public void CannonProjectileInstantiate(Vector2 direction, Vector3 pos, float animationTime)
    {
        GameObject project = Instantiate(projectile, pos, Quaternion.identity);
        project.GetComponent<ProjectileHorizontalAnimation>().StartAnimation(direction, animationTime);
        project.GetComponent<ProjectileCleaner>().StartAnimation(animationTime);
    }

    public void MortireProjectileInstantiate(Vector2 direction, Vector3 pos)
    {
        GameObject project = Instantiate(projectile_mortire, pos, Quaternion.identity);
        project.GetComponent<ProjectileHorizontalAnimation>().StartAnimation(direction);
        project.GetComponent<ProjectileCleaner>().StartAnimation();
    }
}
