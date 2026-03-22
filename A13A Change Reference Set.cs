using System;
using NXOpen;
using NXOpen.Assemblies;

public class NXJournal
{
    public static void Main(string[] args)
    {
        Session theSession = Session.GetSession();
        Part workPart = theSession.Parts.Work;
        ComponentAssembly CompAssy = workPart.ComponentAssembly;
        Component root = CompAssy.RootComponent;
        Component[] comp1 = new Component[1];
        Component[] children = root.GetChildren();
        int num = 0;
        if (num < children.Length)
        {
            Component child = children[num];
            if (child != null)
            {
                Guide.InfoWriteLine("Component Name: " + child.DisplayName);
                Guide.InfoWriteLine("Component Reference Set Name: " + child.ReferenceSet);
                workPart.ComponentAssembly.ReplaceReferenceSet(child, "Entire Part");
                Guide.InfoWriteLine("Component Reference Set Name Changed to: " + child.ReferenceSet);
            }
        }

    }
    public static int GetUnloadOption(string dummy)
    {
        return 1;
    }
}