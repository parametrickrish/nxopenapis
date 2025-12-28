using System;
using NXOpen;
using NXOpen.Features;

public class GeometryHelper
{
    private Session _session;
    private Part _workPart;

    public GeometryHelper()
    {
        _session = Session.GetSession();
        // It's safer to fetch the work part every time the helper is initialized
        _workPart = _session.Parts.Work;
    }

    public Block CreateSimpleBlock(double x, double y, double z, string length, string width, string height)
    {
        if (_workPart == null) return null;

        // 1. Initialize the Builder
        BlockFeatureBuilder blockBuilder = _workPart.Features.CreateBlockFeatureBuilder(null);

        // 2. Set the Origin
        Point3d origin = new Point3d(x, y, z);
        blockBuilder.SetOrigin(origin);

        // 3. Set Dimensions (NX uses strings for RHS to allow expressions)
        blockBuilder.Length.RightHandSide = length;
        blockBuilder.Width.RightHandSide = width;
        blockBuilder.Height.RightHandSide = height;

        // 4. Commit and Clean up
        // Note: Commit returns an NXObject, we cast it to Feature
        Feature blockFeature = (Feature)blockBuilder.Commit();
        blockBuilder.Destroy();

        return (Block)blockFeature;
    }
}

// In NX, all code must live inside a class. 
// "Main" is the entry point for the Journal.
public class Program
{
    public static void Main(string[] args)
    {
        GeometryHelper helper = new GeometryHelper();

        try
        {
            // The Abstraction in action: clean, readable commands.
            helper.CreateSimpleBlock(0, 0, 0, "100", "50", "25");
            helper.CreateSimpleBlock(150, 0, 0, "10", "10", "10");
        }
        catch (Exception ex)
        {
            // Simple error reporting in NX
            Session.GetSession().ListingWindow.Open();
            Session.GetSession().ListingWindow.WriteMessage("Error: " + ex.Message);
        }
    }

    // Required for NX Journals to tell the system how to unload the library
    public static int GetUnloadOption(string dummy) { return (int)Session.LibraryUnloadOption.Immediately; }
}