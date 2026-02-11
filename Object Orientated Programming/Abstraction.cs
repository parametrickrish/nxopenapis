using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.Runtime.InteropServices;
namespace EnableContourSelection_CSharp.csproj
{
    partial class SolidWorksMacro
    {

        ModelDoc2 swModel;
        object vSkLines;
        bool boolstatus;

        public void Main()
        {
            
            string parttemplate = "";
            parttemplate = swApp.GetUserPreferenceStringValue((int)swUserPreferenceStringValue_e.swDefaultTemplatePart);
            swModel = (ModelDoc2)swApp.NewDocument(parttemplate, 0, 0, 0);
            //swModel = (ModelDoc2)swApp.NewDocument("C:\\ProgramData\\SOLIDWORKS\\SOLIDWORKS 2014\ emplates\\Part.prtdot", 0, 0, 0);
            swModel = (ModelDoc2)swApp.ActiveDoc;
            boolstatus = swModel.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swDisplayOrigins, true);
            swModel.ClearSelection2(true);

            vSkLines = swModel.SketchManager.CreateCornerRectangle(-0.0390769010920735, 0.0405984975017191, 0, 0.0129020232818107, -0.0166534302871355, 0);
            swModel.ClearSelection2(true);
            vSkLines = swModel.SketchManager.CreateCornerRectangle(-0.00751826843645631, 0.0156092594749566, 0, 0.0487922329685375, -0.041704950991857, 0);
            swModel.ClearSelection2(true);
            swModel.SketchManager.InsertSketch(true);

            // Enable contour selection
            ((SelectionMgr)(swModel.SelectionManager)).EnableContourSelection = true;
            // Select a contour to extrude
            swModel.Extension.SelectByID2("Sketch1", "SKETCHREGION", 0, 0.01, 0, true, 4, null, 0);
            swModel.FeatureManager.FeatureExtrusion3(true, false, false, 0, 0, 0.01, 0.01, false, false, false,
            false, 0, 0, false, false, false, false, true, true, true,
            0, 0, false);
            // Disable contour selection
            ((SelectionMgr)(swModel.SelectionManager)).EnableContourSelection = false;
            swModel.ClearSelection2(true);

        }

        public SldWorks swApp;

    }

}

