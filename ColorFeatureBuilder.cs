
using System;
using NXOpen;
using NXOpen.UF;

public class NXJournal
{
    public static void Main(string[] args)
    {
        NXOpen.Session theSession = NXOpen.Session.GetSession();
        NXOpen.Part workPart = theSession.Parts.Work;
        NXOpen.Part displayPart = theSession.Parts.Display;
       

        NXOpen.Features.ColorFeatureBuilder colorFeatureBuilder1;
        colorFeatureBuilder1 = workPart.Features.CreateColorFeatureBuilder();
             

        NXOpen.Features.Feature[] objects1 = new NXOpen.Features.Feature[1];
        //NXOpen.Features.Extrude extrude1 = (NXOpen.Features.Extrude)workPart.Features.FindObject("EXTRUDE(2)");
        
        UI theUI = UI.GetUI();
        NXOpen.Features.Feature selectedFeature = null;
        Selection selManager = theUI.SelectionManager;
        TaggedObject obj;
        Point3d cursor = new NXOpen.Point3d(0, 0, 0);
        string cue = "Please select feature";
        string title = "Feature Selection";
        bool highlight = false;
        Selection.MaskTriple featureMask = new Selection.MaskTriple(
    UFConstants.UF_solid_type, // Type for solid bodies (features belong to solids)
    UFConstants.UF_feature_type, // Sub-type for features
    0 // Specific type (0 for any feature, or a specific UF_feature_xxx constant)
);
        Selection.MaskTriple[] mask = { featureMask };
        Selection.Response response = selManager.SelectTaggedObject(
            cue,
            title,
            Selection.SelectionScope.WorkPart,
            Selection.SelectionAction.ClearAndEnableSpecific,
            highlight,
            highlight,
            mask,
            out obj,
            out cursor
        );

        if (response == Selection.Response.ObjectSelected) // Check for successful selection
        {
            Body objbody = (NXOpen.Body)obj;

            NXOpen.Features.Feature[] objFeature = objbody.GetFeatures();

            if (objFeature[0] is NXOpen.Features.Feature)
            {
                selectedFeature = (NXOpen.Features.Feature)objFeature[0];
                theUI.NXMessageBox.Show("Feature Selected", NXMessageBox.DialogType.Information, "Selected Feature: " + selectedFeature.JournalIdentifier);
            }
        }



        objects1[0] = selectedFeature;
        bool added1;
        added1 = colorFeatureBuilder1.SelectFeature.Add(objects1);
        if (added1)
        {
            colorFeatureBuilder1.SpecifyColor = NXOpen.Features.ColorFeatureBuilder.OperationType.SpecifyColor;

            int colorIndex = 175;


            NXOpen.NXObject nXObject1;
            nXObject1 = colorFeatureBuilder1.Commit();

            colorFeatureBuilder1.Destroy();
        }

        else {
            theUI.NXMessageBox.Show("Feature creation", NXMessageBox.DialogType.Information, "Feature creation failed due to improper selection");
        }




    }
    public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
