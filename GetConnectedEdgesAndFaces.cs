
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using NXOpen;
using NXOpen.UF;
using NXOpen.Features;
using NXOpen.Utilities;
using static NXOpen.UF.UFDisp;
using System.Linq;


public class NXJournal
{
    public static void Main(string[] args)
    {
        Session theSession = Session.GetSession();
        UFSession theUFSession = UFSession.GetUFSession();

        Part workPart = theSession.Parts.Work;

        UI theUI = UI.GetUI();

        NXOpen.Face selectedFace = null;
        Selection selManager = theUI.SelectionManager;
        TaggedObject obj;
        Point3d cursor = new NXOpen.Point3d(0, 0, 0);
        string cue = "Please select a face";
        string title = "Face Selection";
        bool highlight = false;

        Selection.MaskTriple faceMask = new Selection.MaskTriple(
            NXOpen.UF.UFConstants.UF_solid_type,
            0,
            NXOpen.UF.UFConstants.UF_UI_SEL_FEATURE_ANY_FACE
        );

        Selection.MaskTriple[] mask = { faceMask };

        // Select a face
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

        if (response != Selection.Response.Cancel && response != Selection.Response.Back)
        {
            DisplayableObject dispObj = obj as DisplayableObject;
            if (dispObj != null)
            {
                selectedFace = (NXOpen.Face)dispObj;
                theSession.ListingWindow.Open();
                theSession.ListingWindow.WriteLine("Selected face: " + selectedFace.JournalIdentifier);
            }
        }
                
        Edge[] edg = selectedFace.GetEdges();
        NXOpen.Tag[] FacetagList;

        List<Edge> edgeList = new List<Edge>();
        List<Face> NewFaceList = new List<Face>();

        // HashSets to track unique Tags
        HashSet<Tag> edgeTagSet = new HashSet<Tag>();
        HashSet<Tag> faceTagSet = new HashSet<Tag>();

        // Add original edges to list and edgeTagSet
        foreach (Edge edge in edg)
        {
            edgeList.Add(edge);
            edgeTagSet.Add(edge.Tag);
        }

        // Loop through each edge to find connected faces
        foreach (Edge edge in edgeList)
        {
            theUFSession.Modl.AskEdgeFaces(edge.Tag, out FacetagList);
            foreach (NXOpen.Tag fctg in FacetagList)
            {
                if (fctg != selectedFace.Tag && !faceTagSet.Contains(fctg))
                {
                    Face fc = (Face)NXObjectManager.Get(fctg);
                    if (fc != null)
                    {
                        NewFaceList.Add(fc);
                        faceTagSet.Add(fctg);
                    }
                }
            }
        }

        // Get edges from connected faces and add only new ones
        foreach (Face fc in NewFaceList)
        {
            Edge[] newEdges = fc.GetEdges();

            foreach (Edge newEdge in newEdges)
            {
                if (!edgeTagSet.Contains(newEdge.Tag))
                {
                    edgeList.Add(newEdge);
                    edgeTagSet.Add(newEdge.Tag);
                }
            }
        }

        // Highlight 
        foreach (Face face in NewFaceList)
        {
            if (face != null)
            {
                face.Highlight();
            }
        }

        // Highlight 
        foreach (Edge edge in edgeList)
        {
            if (edge != null)
            {
                edge.Highlight();
            }
        }

        // Show counts in a message box
        string message = $"Total Edges: {edgeList.Count}\nTotal Connected Faces (excluding selected): {NewFaceList.Count}";
        NXOpen.UI.GetUI().NXMessageBox.Show("Edge and Face Info", NXOpen.NXMessageBox.DialogType.Information, message);
                

    }
    public static int GetUnloadOption(string dummy)
    {
        return (int)NXOpen.Session.LibraryUnloadOption.Immediately;
    }
}





