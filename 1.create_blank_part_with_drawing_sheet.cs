using System;
using NXOpen;
public class create_blank_part_with_drawing_sheet
{
    public static void Main(string[] args)
    {
        Session theSession = Session.GetSession();
        FileNew fileNew1;
        fileNew1 = theSession.Parts.FileNew();
        fileNew1.TemplateFileName = "Blank";
        fileNew1.Application = FileNewApplication.Gateway;
        fileNew1.Units = NXOpen.Part.Units.Millimeters;
        fileNew1.NewFileName = @"C:\temp\test.prt";
        fileNew1.UseBlankTemplate = true;
        fileNew1.MakeDisplayedPart = true;
        NXObject nXObject1 = fileNew1.Commit();
        fileNew1.Destroy();
        Part workPart = theSession.Parts.Work;
        Part displayPart = theSession.Parts.Display;
        NXOpen.Drawings.DrawingSheet nullDrawings_DrawingSheet = null;
        NXOpen.Drawings.DrawingSheetBuilder drawingSheetBuilder1;
        drawingSheetBuilder1 =
        workPart.DrawingSheets.DrawingSheetBuilder(nullDrawings_DrawingSheet);
        drawingSheetBuilder1.Option =
        NXOpen.Drawings.DrawingSheetBuilder.SheetOption.StandardSize;
        drawingSheetBuilder1.Units =
        NXOpen.Drawings.DrawingSheetBuilder.SheetUnits.Metric;
        drawingSheetBuilder1.StandardMetricScale =
        NXOpen.Drawings.DrawingSheetBuilder.SheetStandardMetricScale.S11;
        drawingSheetBuilder1.Height = 210.0;
        drawingSheetBuilder1.Length = 297.0;
        drawingSheetBuilder1.ProjectionAngle =
        NXOpen.Drawings.DrawingSheetBuilder.SheetProjectionAngle.First;
        NXObject nXObject2 = drawingSheetBuilder1.Commit();
        drawingSheetBuilder1.Destroy();
        // Application Switch will be performed AFTER program ends, see Docs.
        UI.GetUI().MenuBarManager.ApplicationSwitchRequest("UG_APP_DRAFTING")
        ;
        // Part is saved but Application is NOT Drafting yet!
        displayPart.Save(BasePart.SaveComponents.False,
        BasePart.CloseAfterSave.False);
    }
    public static int GetUnloadOption(string dummy)
    {
        return
    (int)Session.LibraryUnloadOption.Immediately;
    }
}