using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public bool hasPackage = false;

    public int packagesLeft;
    //purple color for our car, when it has a package 
    [SerializeField] Color32 hasPackageColor = new Color32 (255,93,198,255);
    //Normal color, for when our car has no package 
    [SerializeField] Color32 noPackageColor = new Color32 (255,255,255,255);
    //[SerializeField] private float delayUnitlDestroyed = 0.1f;
    SpriteRenderer carRenderer;

    void Start(){
        //here we are indicating that our renderer is the SpriteRenderer of the Object that this script makes reference to
        carRenderer = GetComponent<SpriteRenderer>();
        packagesLeft = 15;
    } 
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Hello, a collision just happened");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "package" && !hasPackage){
            Debug.Log("you just picked a package");
            hasPackage = true;
            Destroy(other.gameObject,0);
            carRenderer.color = hasPackageColor;
        }
        else if(other.tag == "customer" && hasPackage){
            Debug.Log("You just delivered a package to a customer");
            hasPackage = false; 
            carRenderer.color = noPackageColor;
            packagesLeft--;
            Debug.Log(packagesLeft);
        }
    }
}
