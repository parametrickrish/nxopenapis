public class Cylinder
{
    public string BoreDiameter { get; set; }
    public string RodDiameter { get; set; }
    public double StrokeLength { get; set; }

    // Constructor to initialize
    public Cylinder(string bore, string rod, double stroke)
    {
        BoreDiameter = bore;
        RodDiameter = rod;
        StrokeLength = stroke;
    }

    // Method to validate rod vs bore combination
    public void ValidateRodDiameter()
    {
        if (BoreDiameter == "5\"")
        {
            if (RodDiameter == "0.5\"" || RodDiameter == "1\"" || RodDiameter == "1.5\"" || RodDiameter == "4\"")
            {
                System.Windows.Forms.MessageBox.Show("This rod diameter is not possible for 5\" bore, choose between 2\", 2.5\", 3\", 3.5\".");
                RodDiameter = "2\"";
            }
        }
        else if (BoreDiameter == "6\"")
        {
            if (RodDiameter == "0.5\"" || RodDiameter == "1\"" || RodDiameter == "1.5\"" || RodDiameter == "2\"")
            {
                System.Windows.Forms.MessageBox.Show("This rod diameter is not possible for 6\" bore, choose between 2.5\", 3\", 3.5\", 4\".");
                RodDiameter = "2.5\"";
            }
        }
    }

    // Method to validate stroke length per rod/bore
    public void ValidateStroke()
    {
        if (BoreDiameter == "5\"" && RodDiameter == "3\"" && StrokeLength < 1.375)
        {
            System.Windows.Forms.MessageBox.Show("Minimum stroke length should be 1.375\"");
        }
        if (BoreDiameter == "6\"" && RodDiameter == "4\"" && StrokeLength < 2)
        {
            System.Windows.Forms.MessageBox.Show("Minimum stroke length should be 2\"");
        }
    }
}

// Example update callback rewritten as a C# method
public int update_cb(NXOpen.BlockStyler.UIBlock block)
{
    try
    {
        if (block == roddiameter || block == strokelength)
        {
            var cyl = new Cylinder(borediameter.ValueAsString, roddiameter.ValueAsString, strokelength.Value);
            cyl.ValidateRodDiameter();
            cyl.ValidateStroke();
        }
    }
    catch (Exception ex)
    {
        theUI.NXMessageBox.Show("Block Styler", NXOpen.NXMessageBox.DialogType.Error, ex.ToString());
    }
    return 0;
}
