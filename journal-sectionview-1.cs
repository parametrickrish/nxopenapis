using System;
using NXOpen;

public class NXJournal
{
  public static void Main(string[] args)
  {
    NXOpen.Session theSession = NXOpen.Session.GetSession();
    NXOpen.Part workPart = theSession.Parts.Work;
    NXOpen.Part displayPart = theSession.Parts.Display;
    // ----------------------------------------------
    //   Menu: Insert->View->Section...
    // ----------------------------------------------
    //NXOpen.Session.UndoMarkId markId1;
    //markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");
    
    NXOpen.NXObject nullNXOpen_NXObject = null;
    NXOpen.Drawings.SectionViewBuilder sectionViewBuilder1;
    sectionViewBuilder1 = workPart.DraftingViews.CreateSectionViewBuilder(nullNXOpen_NXObject);
    
    sectionViewBuilder1.ViewPlacement.Associative = true;
    
    sectionViewBuilder1.ViewPlacement.AlignmentMethod = NXOpen.Drawings.ViewPlacementBuilder.Method.PerpendicularToHingeLine;
    
    //NXOpen.Direction nullNXOpen_Direction = null;
    //sectionViewBuilder1.ViewPlacement.AlignmentVector = nullNXOpen_Direction;
    
    sectionViewBuilder1.ViewPlacement.AlignmentOption = NXOpen.Drawings.ViewPlacementBuilder.Option.ModelPoint;
    
    //sectionViewBuilder1.ViewStyle.ViewStyleOrientation.HingeLine.Associative = true;
    
    //sectionViewBuilder1.SecondaryComponents.ObjectType = NXOpen.Drawings.DraftingComponentSelectionBuilder.Geometry.PrimaryGeometry;
    
    //theSession.SetUndoMarkName(markId1, "Section View Dialog");
    
    //NXOpen.Unit unit1 = (NXOpen.Unit)workPart.UnitCollection.FindObject("MilliMeter");
    //NXOpen.Expression expression1;
    //expression1 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);
    
    NXOpen.Drawings.BaseView baseView1 = (NXOpen.Drawings.BaseView)workPart.DraftingViews.FindObject("Top@1");
    sectionViewBuilder1.ParentView.View.Value = baseView1;
    
    NXOpen.Point point1 = (NXOpen.Point)workPart.Points.FindObject("ENTITY 2 9");
    NXOpen.Point3d point2 = new NXOpen.Point3d(81.5, 61.305707157111343, 10.0);
    sectionViewBuilder1.ViewPlacement.AlignmentPoint.SetValue(point1, baseView1, point2);
    
    //sectionViewBuilder1.ViewStyle.ViewStyleBase.PartName = "D:\\NX Models\\plates-with-holes.prt";
    
    //sectionViewBuilder1.ViewStyle.ViewStyleGeneral.ToleranceValue = 0.024866425992779776;
    
    NXOpen.Point3d vieworigin1 = new NXOpen.Point3d(-81.5, -47.0, 45.5);
    sectionViewBuilder1.ViewStyle.ViewStylePerspective.ViewOrigin = vieworigin1;
    
    NXOpen.Drawings.DraftingBody draftingBody1 = (NXOpen.Drawings.DraftingBody)baseView1.DraftingBodies.FindObject("0 EXTRUDE(2)  0");
    NXOpen.Drawings.DraftingCurve draftingCurve1 = (NXOpen.Drawings.DraftingCurve)draftingBody1.DraftingCurves.FindObject("(Extracted Edge) EDGE * 120 * 200 {(74.339364107334,73.7082923377101,10)(95.8212717853319,61.3057071571113,10)(74.339364107334,48.9031219765126,10) EXTRUDE(2)}");
    NXOpen.Point point3;
    point3 = workPart.Points.CreatePoint(draftingCurve1, NXOpen.SmartObject.UpdateOption.AfterModeling);
    
    //NXOpen.Point3d coordinates1 = new NXOpen.Point3d(55.388537906137159, 123.45351985559566, 0.0);
    //NXOpen.Point point4;
    //point4 = workPart.Points.CreatePoint(coordinates1);
    
    //NXOpen.Point3d coordinates2 = new NXOpen.Point3d(242.38853790613717, 123.45351985559566, 0.0);
    //NXOpen.Point point5;
    //point5 = workPart.Points.CreatePoint(coordinates2);
    
    NXOpen.Drawings.SectionLineSegmentPointBuilder sectionLineSegmentPointBuilder1;
    sectionLineSegmentPointBuilder1 = sectionViewBuilder1.SectionLineSegments.SegmentLocation.AddCutSegment(point3);
    
    //NXOpen.Point3d coordinates3 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates3;
    
    //NXOpen.Point3d coordinates4 = new NXOpen.Point3d(0.0, 0.0, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates4;
    
    //sectionViewBuilder1.ViewPlacement.AlignmentView.Value = baseView1;
    
    //NXOpen.Point3d coordinates5 = new NXOpen.Point3d(146.93546931407946, 135.4354693140794, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates5;
    
    //NXOpen.Point3d coordinates6 = new NXOpen.Point3d(148.5, 85.702617328519835, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates6;
    
    //NXOpen.Point3d coordinates7 = new NXOpen.Point3d(148.5, 45.812725631768949, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates7;
    
    //NXOpen.Point3d coordinates8 = new NXOpen.Point3d(148.5, 41.409296028880853, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates8;
    
    //NXOpen.Point3d coordinates9 = new NXOpen.Point3d(148.5, 40.891245487364614, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates9;
    
    //NXOpen.Point3d coordinates10 = new NXOpen.Point3d(148.5, 40.891245487364614, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates10;
    
    //NXOpen.Point3d coordinates11 = new NXOpen.Point3d(148.5, 40.891245487364614, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates11;
    
    //NXOpen.Point3d coordinates12 = new NXOpen.Point3d(148.5, 40.632220216606498, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates12;
    
    //NXOpen.Point3d coordinates13 = new NXOpen.Point3d(148.5, 37.264891696750894, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates13;
    
    //NXOpen.Point3d coordinates14 = new NXOpen.Point3d(148.5, 33.379512635379072, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates14;
    
    //NXOpen.Point3d coordinates15 = new NXOpen.Point3d(148.5, 32.084386281588451, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates15;
    
    //NXOpen.Point3d coordinates16 = new NXOpen.Point3d(148.5, 30.530234657039713, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates16;
    
    //NXOpen.Point3d coordinates17 = new NXOpen.Point3d(148.5, 30.530234657039713, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates17;
    
    //NXOpen.Point3d coordinates18 = new NXOpen.Point3d(148.5, 30.271209386281598, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates18;
    
    //NXOpen.Point3d coordinates19 = new NXOpen.Point3d(148.5, 29.753158844765338, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates19;
    
    //NXOpen.Point3d coordinates20 = new NXOpen.Point3d(148.5, 29.494133574007208, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates20;
    
    //NXOpen.Point3d coordinates21 = new NXOpen.Point3d(148.5, 29.235108303249092, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates21;
    
    //NXOpen.Point3d coordinates22 = new NXOpen.Point3d(148.5, 28.199007220216615, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates22;
    
    //NXOpen.Point3d coordinates23 = new NXOpen.Point3d(148.5, 24.05460288808662, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates23;
    
    //NXOpen.Point3d coordinates24 = new NXOpen.Point3d(148.5, 21.723375451263522, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates24;
    
    //NXOpen.Point3d coordinates25 = new NXOpen.Point3d(148.5, 20.428249097472914, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates25;
    
    //NXOpen.Point3d coordinates26 = new NXOpen.Point3d(148.5, 20.428249097472914, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates26;
    
    //NXOpen.Point3d coordinates27 = new NXOpen.Point3d(148.5, 20.169223826714813, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates27;
    
    //NXOpen.Point3d coordinates28 = new NXOpen.Point3d(148.5, 20.169223826714813, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates28;
    
    //NXOpen.Point3d coordinates29 = new NXOpen.Point3d(148.5, 19.910198555956669, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates29;
    
    //NXOpen.Point3d coordinates30 = new NXOpen.Point3d(148.5, 19.651173285198567, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates30;
    
    //NXOpen.Point3d coordinates31 = new NXOpen.Point3d(148.5, 19.651173285198567, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates31;
    
    //NXOpen.Point3d coordinates32 = new NXOpen.Point3d(148.5, 19.651173285198567, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates32;
    
    //NXOpen.Point3d coordinates33 = new NXOpen.Point3d(148.5, 19.133122743682293, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates33;
    
    //NXOpen.Point3d coordinates34 = new NXOpen.Point3d(148.5, 18.874097472924191, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates34;
    
    //NXOpen.Point3d coordinates35 = new NXOpen.Point3d(148.5, 18.356046931407946, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates35;
    
    //NXOpen.Point3d coordinates36 = new NXOpen.Point3d(148.5, 18.097021660649816, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates36;
    
    //NXOpen.Point3d coordinates37 = new NXOpen.Point3d(148.5, 17.837996389891714, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates37;
    
    //NXOpen.Point3d coordinates38 = new NXOpen.Point3d(148.5, 17.837996389891714, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates38;
    
    //NXOpen.Point3d coordinates39 = new NXOpen.Point3d(148.5, 17.57897111913357, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates39;
    
    //NXOpen.Point3d coordinates40 = new NXOpen.Point3d(148.5, 17.31994584837544, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates40;
    
    //NXOpen.Point3d coordinates41 = new NXOpen.Point3d(148.5, 17.31994584837544, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates41;
    
    //NXOpen.Point3d coordinates42 = new NXOpen.Point3d(148.5, 17.31994584837544, 0.0);
    //sectionViewBuilder1.SectionLineSegments.SectionLineOnlyPlacementOrigin = coordinates42;
    
    //NXOpen.Point3d point6 = new NXOpen.Point3d(148.5, 17.31994584837544, 0.0);
    //sectionViewBuilder1.ViewPlacement.Placement.SetValue(null, workPart.Views.WorkView, point6);
    
    //NXOpen.Session.UndoMarkId markId2;
    //markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Section View");
    
    NXOpen.NXObject nXObject1;
    nXObject1 = sectionViewBuilder1.Commit();
    
    //theSession.DeleteUndoMark(markId2, null);
    
    //theSession.SetUndoMarkName(markId1, "Section View");
    
    //theSession.SetUndoMarkVisibility(markId1, null, NXOpen.Session.MarkVisibility.Visible);
    
    sectionViewBuilder1.Destroy();
    
    //workPart.Expressions.Delete(expression1);
    
    //NXOpen.Session.UndoMarkId markId3;
    //markId3 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Start");
    
    //NXOpen.Drawings.SectionViewBuilder sectionViewBuilder2;
    //sectionViewBuilder2 = workPart.DraftingViews.CreateSectionViewBuilder(nullNXOpen_NXObject);
    
    //sectionViewBuilder2.ViewPlacement.Associative = true;
    
    //sectionViewBuilder2.ViewPlacement.AlignmentMethod = NXOpen.Drawings.ViewPlacementBuilder.Method.PerpendicularToHingeLine;
    
    //sectionViewBuilder2.ViewPlacement.AlignmentVector = nullNXOpen_Direction;
    
    //sectionViewBuilder2.ViewPlacement.AlignmentOption = NXOpen.Drawings.ViewPlacementBuilder.Option.ModelPoint;
    
    //sectionViewBuilder2.ViewStyle.ViewStyleOrientation.HingeLine.Associative = true;
    
    //sectionViewBuilder2.SecondaryComponents.ObjectType = NXOpen.Drawings.DraftingComponentSelectionBuilder.Geometry.PrimaryGeometry;
    
    //theSession.SetUndoMarkName(markId3, "Section View Dialog");
    
    //NXOpen.Expression expression2;
    //expression2 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1);
    
    //sectionViewBuilder2.Destroy();
    
    //workPart.Expressions.Delete(expression2);
    
    //theSession.UndoToMark(markId3, null);
    
    //theSession.DeleteUndoMark(markId3, null);
    
    // ----------------------------------------------
    //   Menu: Tools->Journal->Stop Recording
    // ----------------------------------------------
    
  }
  public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
