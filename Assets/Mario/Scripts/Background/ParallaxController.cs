using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ParallaxZone
{
    public string zoneName;
    public Rect zoneBounds; // The area where this background is active
    public Transform parallaxParent; // Reference all layers that should be ON in this zone
}

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private ParallaxZone[] zones;
    [SerializeField] private Transform player; // Reference to player transform

    private ParallaxZone currentZone;

    void Start()
    {
        // Start with all parallax parents disabled
        foreach (ParallaxZone zone in zones)
        {
            if (zone.parallaxParent != null)
            {
                zone.parallaxParent.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        CheckZoneTransition();
    }

    private void CheckZoneTransition()
    {
        Vector2 playerPos = player.position;
        ParallaxZone targetZone = null;

        // Find which zone the player is in
        foreach (ParallaxZone zone in zones)
        {
            if (zone.zoneBounds.Contains(playerPos))
            {
                targetZone = zone;
                break;
            }
        }

        // If zone changed, switch backgrounds
        if (targetZone != currentZone)
        {
            SwitchToZone(targetZone);
        }
    }

    private void SwitchToZone(ParallaxZone newZone)
    {
        // Disable current zone's parent
        if (currentZone != null && currentZone.parallaxParent != null)
        {
            currentZone.parallaxParent.gameObject.SetActive(false);
        }
        // Enable new zone's parent
        if (newZone != null && newZone.parallaxParent != null)
        {
            newZone.parallaxParent.gameObject.SetActive(true);
            Debug.Log($"Entered zone: {newZone.zoneName}");
        }
        else
        {
            Debug.Log("No background zone - default background");
        }

        currentZone = newZone;
    }


    // Visualize zones in Scene view
    private void OnDrawGizmosSelected()
    {
        if (zones != null)
        {
            Gizmos.color = Color.cyan;
            foreach (ParallaxZone zone in zones)
            {
                Gizmos.DrawWireCube(zone.zoneBounds.center, zone.zoneBounds.size);
            }
        }
    }
}


