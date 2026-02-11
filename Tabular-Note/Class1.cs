using System;
using NXOpen;

public class NXJournal
{
    public static void Main(string[] args)
    {
        NXOpen.Session theSession = NXOpen.Session.GetSession();
        NXOpen.Part workPart = theSession.Parts.Work;
        NXOpen.Part displayPart = theSession.Parts.Display;
       
        NXOpen.Annotations.Table table1 = ((NXOpen.Annotations.Table)workPart.Annotations.Tables.FindObject("ENTITY 165 12 1"));
        NXOpen.DisplayableObject displayableObject1 = ((NXOpen.DisplayableObject)workPart.FindObject("ENTITY 218 12 1"));
        table1.EditCellText(displayableObject1, "345");

        // ----------------------------------------------
        //   Menu: Tools->Automation->Journal->Stop Recording
        // ----------------------------------------------

    }
    public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
