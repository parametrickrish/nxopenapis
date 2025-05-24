using System;
using NXOpen;
using NXOpen.Drawings;
using static NXOpen.CAM.FBM.ThreadFeatureGeometry;

public class NXJournal
{
    public static void Main(string[] args)
    {
        NXOpen.Session theSession = NXOpen.Session.GetSession();
        NXOpen.Part workPart = theSession.Parts.Work;
        NXOpen.Part displayPart = theSession.Parts.Display;

        NXOpen.NXObject nullNXOpen_NXObject = null;
        NXOpen.Drawings.SectionViewBuilder sectionViewBuilder1;
        sectionViewBuilder1 = workPart.DraftingViews.CreateSectionViewBuilder(nullNXOpen_NXObject);

        sectionViewBuilder1.ViewPlacement.Associative = true;

        sectionViewBuilder1.ViewPlacement.AlignmentMethod = NXOpen.Drawings.ViewPlacementBuilder.Method.PerpendicularToHingeLine;

        sectionViewBuilder1.ViewPlacement.AlignmentOption = NXOpen.Drawings.ViewPlacementBuilder.Option.ModelPoint;

        DrawingSheet laSheet = workPart.DrawingSheets.CurrentDrawingSheet;
        NXOpen.Drawings.DraftingView baseView1 = null;

        if (laSheet != null)
        {
            // Iterate through the drafting views on the current sheet
            foreach (DraftingView drfview in laSheet.SheetDraftingViews)
            {
                string viewName = drfview.Name;
                baseView1 = drfview;
            }

        }

        sectionViewBuilder1.ParentView.View.Value = baseView1;

        NXOpen.Drawings.DraftingBodyCollection draftingBodyColl = baseView1.DraftingBodies;

        NXOpen.Drawings.DraftingBody draftingbBody = null;

        foreach (DraftingBody draftingbBody1 in draftingBodyColl)
        {
            draftingbBody = draftingbBody1;
        }

        foreach (NXOpen.Drawings.DraftingCurve draftingCurve in draftingbBody.DraftingCurves)
        {
            //Assignment 
            // check if the found drafting curve is circle, if circle then assign the object to variable draftingCurve1 and continue
        }

        //NXOpen.Drawings.DraftingBody draftingBody1 = (NXOpen.Drawings.DraftingBody)baseView1.DraftingBodies.FindObject("0 EXTRUDE(2)  0");
        NXOpen.Drawings.DraftingCurve draftingCurve1 = (NXOpen.Drawings.DraftingCurve)draftingbBody.DraftingCurves.FindObject("(Extracted Edge) EDGE * 120 * 200 {(74.339364107334,73.7082923377101,10)(95.8212717853319,61.3057071571113,10)(74.339364107334,48.9031219765126,10) EXTRUDE(2)}");
        NXOpen.Point point3;
        point3 = workPart.Points.CreatePoint(draftingCurve1, NXOpen.SmartObject.UpdateOption.AfterModeling);

        NXOpen.Drawings.SectionLineSegmentPointBuilder sectionLineSegmentPointBuilder1;
        sectionLineSegmentPointBuilder1 = sectionViewBuilder1.SectionLineSegments.SegmentLocation.AddCutSegment(point3);

        NXOpen.NXObject nXObject1;
        nXObject1 = sectionViewBuilder1.Commit();

        sectionViewBuilder1.Destroy();

    }
    public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
